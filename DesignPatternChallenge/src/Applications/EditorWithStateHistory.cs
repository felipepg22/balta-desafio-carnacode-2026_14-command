using System;
using System.Collections.Generic;
using DesignPatternChallenge.Editor;

namespace DesignPatternChallenge.Applications
{
    public class EditorWithStateHistory
    {
        private TextEditor _editor;
        private Stack<string> _contentHistory;

        public EditorWithStateHistory()
        {
            _editor = new TextEditor();
            _contentHistory = new Stack<string>();
        }

        public void TypeText(string text)
        {
            _contentHistory.Push(_editor.GetContent());
            _editor.InsertText(text);
        }

        public void DeleteCharacters(int count)
        {
            _contentHistory.Push(_editor.GetContent());
            _editor.DeleteText(count);
        }

        public void Undo()
        {
            if (_contentHistory.Count > 0)
            {
                string previousContent = _contentHistory.Pop();
                Console.WriteLine($"[Undo] Restaurando estado anterior");
            }
        }
    }
}