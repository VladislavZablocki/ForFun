using System;


namespace NotePad
{
    /// <summary>
    /// Class which set method to notebookprovider and run it
    /// </summary>
    class Invoker
    {
        private ICommand command;
        private CommandCreator allCommand;
        public Invoker(CommandCreator allCommand)
        {
            this.allCommand = allCommand;
        }
        /// <summary>
        /// set command to notebook provider
        /// </summary>
        /// <param name="inputCommand">string command from console</param>
        public void SetCommand(string inputCommand)
        {
            command = allCommand.CreateCommand(new NoteBookProvider(new CreateCommandAddNote(null)) , inputCommand);  //!!!!!   
        }

        /// <summary>
        /// run command
        /// </summary>
        public void Run()
        {
            command.Execute();
        }
    }
}
