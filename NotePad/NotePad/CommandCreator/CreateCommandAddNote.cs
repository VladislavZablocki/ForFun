using System;

namespace NotePad
{
    class CreateCommandAddNote : CommandCreator
    {
        private string addNote;
        public CreateCommandAddNote(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public override ICommand CreateCommand(NoteBookProvider provider, string commandString)
        {
            ICommand command = null;
            if (commandString.Contains(Resources.AddNote))
            {
                command = new AddNoteCommand(provider.GetNoteBook(), addNote); 
            }
            else if (Successor != null)
            {
                Successor.CreateCommand(provider, commandString);
            }
            return command;
        }

        public override void ParseCommandLine(string commandString)
        {
            addNote = commandString.Split(separators, 2)[1];
        }
    }
}
