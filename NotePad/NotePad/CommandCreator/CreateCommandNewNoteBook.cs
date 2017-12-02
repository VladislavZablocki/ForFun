﻿using System;

namespace NotePad
{
    class CreateCommandNewNoteBook : CommandCreator
    {
        public CreateCommandNewNoteBook(CommandCreator Successor)
        {
            this.Successor = Successor;
        }

        public override ICommand CreateCommand(NoteBookProvider provider, string commandString)
        {
            ICommand command = null;
            if (commandString.Contains(Resources.NewNoteBook))
            {
                command = new NewNoteBookCommand();
            }
            else if (Successor!=null)
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
