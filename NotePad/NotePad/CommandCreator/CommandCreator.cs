using System;

namespace NotePad
{
    public abstract class CommandCreator
    {
        public char[] separators = { ' ' }; 
        public CommandCreator Successor { get; set; }
        public abstract ICommand CreateCommand(NoteBookProvider provider, string commandString);
        public abstract void ParseCommandLine(string commandString);
    }
}
