using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.Commands
{
    public class SetCursorPositionCommand : ICommand
    {
        private readonly TextEditor _textEditor;
        private readonly int _newPosition;
        private int _previousPosition;

        public SetCursorPositionCommand(TextEditor textEditor, int newPosition)
        {
            _textEditor = textEditor;
            _newPosition = newPosition;
        }

        public void Execute()
        {
            _previousPosition = _textEditor.GetCursorPosition();
            _textEditor.SetCursorPosition(_newPosition);
        }

        public void Undo()
        {
            _textEditor.SetCursorPosition(_previousPosition);
        }

        public void Redo()
        {
            _textEditor.SetCursorPosition(_newPosition);
        }
    }
}