using System;
using System.Collections.Generic;
using DesignPatternChallenge.Commands;
using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.Applications
{
    public class EditorWithOperationLog
    {
        private readonly TextEditor _editor;
        private readonly CommandInvoker _invoker;
        private readonly List<string> _operationLog = new List<string>();

        public EditorWithOperationLog()
        {
            _editor = new TextEditor();
            _invoker = new CommandInvoker();
        }

        private void Log(string action, string details)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            var logEntry = $"[{timestamp}] {action}: {details} | cursor={_editor.GetCursorPosition()} content='{_editor.GetContent()}'";
            _operationLog.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void TypeText(string text)
        {
            var command = new WriteTextCommand(_editor, text);
            _invoker.ExecuteCommand(command);
            Log("TypeText", $"text='{text}'");
        }

        public void DeleteCharacters(int count)
        {
            var command = new DeleteTextCommand(_editor, count);
            _invoker.ExecuteCommand(command);
            Log("DeleteCharacters", $"count={count}");
        }

        public void MakeBold(int start, int length)
        {
            var command = new MakeTextBoldCommand(_editor, start, length);
            _invoker.ExecuteCommand(command);
            Log("MakeBold", $"start={start} length={length}");
        }

        public void Undo()
        {
            if (_invoker.CanUndo)
            {
                _invoker.Undo();
                Log("Undo", "executed");
                return;
            }

            Log("Undo", "skipped (empty stack)");
        }

        public void Redo()
        {
            if (_invoker.CanRedo)
            {
                _invoker.Redo();
                Log("Redo", "executed");
                return;
            }

            Log("Redo", "skipped (empty stack)");
        }

        public string GetContent() => _editor.GetContent();
        public int GetCursorPosition() => _editor.GetCursorPosition();

        public void ShowContent()
        {
            Console.WriteLine($"\n=== Conteúdo do Editor ===");
            Console.WriteLine($"'{_editor.GetContent()}'");
            Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
            Log("ShowContent", "executed");
        }

        public IReadOnlyList<string> GetOperationLog()
        {
            return _operationLog.AsReadOnly();
        }

        public void ShowOperationLog()
        {
            Console.WriteLine("\n=== Operation Log ===");
            foreach (var entry in _operationLog)
            {
                Console.WriteLine(entry);
            }
            Console.WriteLine();
        }

        public void ClearOperationLog()
        {
            _operationLog.Clear();
        }
    }
}