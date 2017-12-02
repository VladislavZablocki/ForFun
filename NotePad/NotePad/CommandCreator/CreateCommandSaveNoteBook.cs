using System;

namespace NotePad
{
    class CreateCommandSaveNoteBook : CommandCreator
    {
        public CreateCommandSaveNoteBook(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public CreateCommandSaveNoteBook()
        { }

        public override ICommand CreateCommand(NoteBookProvider provider, string commandString)
        {
            ICommand command = null;
            if (commandString.Contains(Resources.SaveNoteBook))
            {
                command = new SaveNoteBookCommand();
            }
            else if (Successor != null)
            {
                command = Successor.CreateCommand(provider, commandString);
            }
            return command;
        }

        public override void ParseCommandLine(string commandString)
        {
            throw new NotImplementedException();
        }
    }
}
