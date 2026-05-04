using DesignPatternChallenge.Editors;

namespace DesignPatternChallenge.Commands
{
    public class DeleteTextCommand : ICommand
    {
        private readonly TextEditor _textEditor;
        private readonly int _length;
        private string _deletedText;
        private int _deletePosition;

        public DeleteTextCommand(TextEditor textEditor, int length)
        {
            _textEditor = textEditor;
            _length = length;
        }

        public void Execute()
        {
            _deletePosition = _textEditor.GetCursorPosition() - _length;
            _deletedText = _textEditor.GetContent().Substring(_deletePosition, _length);
            _textEditor.DeleteText(_length);
        }

        public void Undo()
        {
            _textEditor.SetCursorPosition(_deletePosition);
            _textEditor.InsertText(_deletedText);
        }

        public void Redo()
        {
            _textEditor.SetCursorPosition(_deletePosition + _deletedText.Length);
            _textEditor.DeleteText(_length);
        }
    }
}