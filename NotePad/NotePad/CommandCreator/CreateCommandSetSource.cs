using System;

namespace NotePad
{
    class CreateCommandSetSource : CommandCreator
    {
        private string source;
        public CreateCommandSetSource(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public CreateCommandSetSource()
        { 
        }

        public override ICommand CreateCommand(NoteBookProvider provider, string commandString)
        {
            ICommand command = null;
            if (commandString.Contains(Resources.SetSource))
            {
                ParseCommandLine(commandString);
                command = new SetSourceCommand(provider, source);
            }
            else if (Successor != null)
            {
                command = Successor.CreateCommand(provider, commandString);
            }
            return command;
        }

        public override void ParseCommandLine(string commandString)
        {
            string[] splitCommand = commandString.Split(separators);
            source = splitCommand[1];
        }
    }
}
