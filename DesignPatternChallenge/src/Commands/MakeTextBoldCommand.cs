using System;
using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.Commands;

public class MakeTextBoldCommand : ICommand
{
    private readonly TextEditor _textEditor;
    private readonly int _start;
    private readonly int _end;

    public MakeTextBoldCommand(TextEditor textEditor, int start, int end)
    {
        _textEditor = textEditor;
        _start = start;
        _end = end;
    }

    public void Execute()
    {
        _textEditor.SetBold(_start, _end);
    }

    public void Undo()
    {
        _textEditor.RemoveBold(_start, _end);
    }

    public void Redo()
    {
        _textEditor.SetBold(_start, _end);
    }
}
