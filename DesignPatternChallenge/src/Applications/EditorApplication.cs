using System;
using DesignPatternChallenge.Editors;
using DesignPatternChallenge.src.Commands;
using DesignPatternChallenge.src.Queries;

namespace DesignPatternChallenge.Applications
{
    public class EditorApplication
    {
        public void TypeText(WriteTextCommand writeTextCommand)
        {
            writeTextCommand.Execute();
        }

        public void MakeBold(MakeTextBoldCommand makeTextBoldCommand)
        {
            makeTextBoldCommand.Execute();
        }

        public void Undo(ICommand command)
        {
            command.Undo();
        }

        public void Redo()
        {
            Console.WriteLine("❌ Redo não implementado!");
        }

        public void ShowContent(IQuery query)
        {
           query.Execute();
        }
    }
}