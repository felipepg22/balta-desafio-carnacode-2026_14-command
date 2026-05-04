using System;
using DesignPatternChallenge.Commands;
using DesignPatternChallenge.Editors;
using DesignPatternChallenge.Queries;

namespace DesignPatternChallenge.Applications
{
    public class EditorApplication
    {
        private readonly TextEditor _editor;
        private readonly CommandInvoker _invoker;

        public EditorApplication()
        {
            _editor = new TextEditor();
            _invoker = new CommandInvoker();
        }

        public void TypeText(string text)
        {
            var command = new WriteTextCommand(_editor, text);
            _invoker.ExecuteCommand(command);
        }

        public void DeleteCharacters(int count)
        {
            var command = new DeleteTextCommand(_editor, count);
            _invoker.ExecuteCommand(command);
        }

        public void MakeBold(int start, int length)
        {
            var command = new MakeTextBoldCommand(_editor, start, length);
            _invoker.ExecuteCommand(command);
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

        public void ShowContent()
        {
            Console.WriteLine($"\n=== Conteúdo do Editor ===");
            Console.WriteLine($"'{_editor.GetContent()}'");
            Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
        }
    }
}