using System;
using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.Queries;

public class GetTextContentQuery : IQuery
{
    private readonly TextEditor _textEditor;

    public GetTextContentQuery(TextEditor textEditor)
    {
        _textEditor = textEditor;
    }

    public void Execute()
    {
        Console.WriteLine($"\n=== Conteúdo do Editor ===");
        Console.WriteLine($"'{_textEditor.GetContent()}'");
        Console.WriteLine($"Cursor na posição: {_textEditor.GetCursorPosition()}\n");
    }
}
