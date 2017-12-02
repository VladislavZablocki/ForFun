using System;
using System.Collections.Generic;

namespace NotePad
{
    public class NoteBookProvider
    {
        INoteBookDAO dao;
        private CommandCreator commandCreator;
        private ICommand noteCommand;
        private NoteBook currentNoteBook = new NoteBook();

        public NoteBookProvider(CommandCreator commandCreator)
        {
            this.commandCreator = commandCreator;
        }

        public void SetCommand(string inputCommand)
        {
            noteCommand = commandCreator.CreateCommand(this, inputCommand);
        }

        public void Run()
        {
            noteCommand.Execute();
        }

        public NoteBook GetNoteBook()
        {
            return currentNoteBook;
        }

        public void NewNoteBook()
        {
            currentNoteBook = new NoteBook();
        }

        public void OpenNoteBook()
        {
            dao.OpenNoteBook();
        }

        public void SaveNoteBook()
        {
            dao.SaveNoteBook();
        }

        public void SetSource(string source)
        {
            if (source == Source.json.ToString())
            {
                dao = new DAOJSON();
            }
            else if (source == Source.sql.ToString())
            {
                dao = new DAOSQL();
            }
        }
    }
}
