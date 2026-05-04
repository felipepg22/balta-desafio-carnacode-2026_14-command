using System;

namespace DesignPatternChallenge.src.Commands;

public interface ICommand
{
    void Execute();
    void Undo();
}
