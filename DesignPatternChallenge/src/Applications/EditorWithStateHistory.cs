using System;
using System.Collections.Generic;
using DesignPatternChallenge.Commands;
using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.Applications
{
    public class EditorWithStateHistory
    {
        private readonly TextEditor _editor;
        private readonly CommandInvoker _invoker;
        private readonly Dictionary<string, List<ICommand>> _histories;
        private List<ICommand> _recordingBuffer;
        private string? _currentHistoryName;
        private bool _isRecording;

        public EditorWithStateHistory()
        {
            _editor = new TextEditor();
            _invoker = new CommandInvoker();
            _histories = new Dictionary<string, List<ICommand>>();
            _recordingBuffer = new List<ICommand>();
        }

        public void StartHistory(string historyName)
        {
            if (_isRecording)
            {
                throw new InvalidOperationException("Already recording a history. Stop it first.");
            }

            if (string.IsNullOrWhiteSpace(historyName))
            {
                throw new ArgumentException("History name cannot be empty.");
            }

            _currentHistoryName = historyName;
            _recordingBuffer = new List<ICommand>();
            _isRecording = true;
        }

        public void StopHistory()
        {
            if (!_isRecording)
            {
                throw new InvalidOperationException("Not currently recording.");
            }

            if (_currentHistoryName != null)
            {
                _histories[_currentHistoryName] = new List<ICommand>(_recordingBuffer);
            }

            _isRecording = false;
            _currentHistoryName = null;
            _recordingBuffer = new List<ICommand>();
        }

        public void ReplayHistory(string historyName)
        {
            if (!_histories.ContainsKey(historyName))
            {
                throw new ArgumentException($"History '{historyName}' not found.");
            }

            var commands = _histories[historyName];
            foreach (var command in commands)
            {
                _invoker.ExecuteCommand(command);
            }
        }

        public IEnumerable<string> GetHistoryNames()
        {
            return _histories.Keys;
        }

        public void TypeText(string text)
        {
            var command = new WriteTextCommand(_editor, text);
            _invoker.ExecuteCommand(command);

            if (_isRecording)
            {
                _recordingBuffer.Add(command);
            }
        }

        public void DeleteCharacters(int count)
        {
            var command = new DeleteTextCommand(_editor, count);
            _invoker.ExecuteCommand(command);

            if (_isRecording)
            {
                _recordingBuffer.Add(command);
            }
        }

        public void MakeBold(int start, int length)
        {
            var command = new MakeTextBoldCommand(_editor, start, length);
            _invoker.ExecuteCommand(command);

            if (_isRecording)
            {
                _recordingBuffer.Add(command);
            }
        }

        public void SetCursorPosition(int position)
        {
            var command = new SetCursorPositionCommand(_editor, position);
            _invoker.ExecuteCommand(command);

            if (_isRecording)
            {
                _recordingBuffer.Add(command);
            }
        }

        public void Undo()
        {
            if (_invoker.CanUndo)
            {
                _invoker.Undo();
            }
        }

        public void Redo()
        {
            if (_invoker.CanRedo)
            {
                _invoker.Redo();
            }
        }

        public string GetContent() => _editor.GetContent();
        public int GetCursorPosition() => _editor.GetCursorPosition();

        public void ShowContent()
        {
            Console.WriteLine($"\n=== Conteúdo do Editor ===");
            Console.WriteLine($"'{_editor.GetContent()}'");
            Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
        }
    }
}