using System;
using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.src.Commands;

public class WriteTextCommand : ICommand
{
    private readonly TextEditor _textEditor;
    private readonly string _text;

    public WriteTextCommand(TextEditor textEditor, 
                            string text)
    {
        _textEditor = textEditor;
        _text = text;
    }

    public void Execute()
    {
        _textEditor.InsertText(_text);
    }

    public void Undo()
    {
        _textEditor.DeleteText(_text.Length);
    }
}
