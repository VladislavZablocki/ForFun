namespace NotePad
{
    class AddNoteCommand : ICommand
    {
        private NoteBook noteBook;
        private string commandLine;
        private string title;
        private string author;
        private char[] separators = { ' ' };

        public AddNoteCommand(NoteBook noteBook, string commandLine)
        {
            this.noteBook = noteBook;
            this.commandLine = commandLine;
        }
        public void Execute()
        {
            noteBook.AddNote(commandLine);
        }
        private void ParseCommandLine(string commandLine)
        {
            string[] splitString = commandLine.Split(separators);
        }
    }
}
