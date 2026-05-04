using System;
using System.Collections.Generic;
using DesignPatternChallenge.Editor;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Applications
{
    public class EditorWithOperationLog
    {
        private TextEditor _editor;
        private Stack<Operation> _operations;

        public EditorWithOperationLog()
        {
            _editor = new TextEditor();
            _operations = new Stack<Operation>();
        }

        public void TypeText(string text)
        {
            _operations.Push(new Operation 
            { 
                Type = "Insert", 
                Text = text,
                Position = _editor.GetCursorPosition()
            });
            _editor.InsertText(text);
        }

        public void Undo()
        {
            if (_operations.Count > 0)
            {
                var op = _operations.Pop();
                
                switch (op.Type)
                {
                    case "Insert":
                        _editor.SetCursorPosition(op.Position + op.Text.Length);
                        _editor.DeleteText(op.Text.Length);
                        break;
                    case "Delete":
                        _editor.SetCursorPosition(op.Position);
                        _editor.InsertText(op.Text);
                        break;
                    case "Bold":
                        _editor.RemoveBold(op.Position, op.Length);
                        break;
                }
            }
        }
    }
}