using System;
using DesignPatternChallenge.Editor;

namespace DesignPatternChallenge.Applications
{
    public class EditorApplication
    {
        private TextEditor _editor;

        public EditorApplication()
        {
            _editor = new TextEditor();
        }

        public void TypeText(string text)
        {
            _editor.InsertText(text);
        }

        public void DeleteCharacters(int count)
        {
            _editor.DeleteText(count);
        }

        public void MakeBold(int start, int length)
        {
            _editor.SetBold(start, length);
        }

        public void Undo()
        {
            Console.WriteLine("❌ Undo não implementado - não há histórico de operações!");
        }

        public void Redo()
        {
            Console.WriteLine("❌ Redo não implementado!");
        }

        public void ShowContent()
        {
            Console.WriteLine($"\n=== Conteúdo do Editor ===");
            Console.WriteLine($"'{_editor.GetContent()}'");
            Console.WriteLine($"Cursor na posição: {_editor.GetCursorPosition()}\n");
        }
    }
}