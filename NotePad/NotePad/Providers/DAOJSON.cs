using System;
using System.IO;

namespace NotePad
{
    class DAOJSON : INoteBookDAO
    {
        private NoteBook currentNoteBook = new NoteBook();

        public void OpenNoteBook()
        {
            string path = @"F:\file.json";
            using (StreamReader streamReader = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Note note = Note.JsonStringToNote(line);
                    currentNoteBook.GetNoteList().Add(note);
                }
            }
        }

        public void SaveNoteBook()
        {
            string path = @"F:\file.json";
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (var items in currentNoteBook.GetNoteList())
                {
                    streamWriter.WriteLine(items.NoteToJsonString());
                }
            }
        }
    }
}
