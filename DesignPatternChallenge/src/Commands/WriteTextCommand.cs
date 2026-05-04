using System;
using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.Commands;

public class WriteTextCommand : ICommand
{
    private readonly TextEditor _textEditor;
    private readonly string _text;
    private int _insertPosition;

    public WriteTextCommand(TextEditor textEditor, 
                            string text)
    {
        _textEditor = textEditor;
        _text = text;
    }

    public void Execute()
    {
        _insertPosition = _textEditor.GetCursorPosition();
        _textEditor.InsertText(_text);
    }

    public void Undo()
    {
        _textEditor.SetCursorPosition(_insertPosition + _text.Length);
        _textEditor.DeleteText(_text.Length);
    }

    public void Redo()
    {
        _textEditor.SetCursorPosition(_insertPosition);
        _textEditor.InsertText(_text);
    }
}
