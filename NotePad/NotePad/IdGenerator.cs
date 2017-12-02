using System;
using System.Collections.Generic;
using System.Linq;

namespace NotePad
{
    /// <summary>
    /// Class which contains used id and generate new
    /// </summary>
    public class IdGenerator
    {
        List<int> usedIdForNote = new List<int>();
        List<int> usedIdForNoteBook = new List<int>();

        public void SetUsedIdForNote(List<Note> noteList)
        {
            usedIdForNote = noteList.Select(list => list.Id).ToList<int>();
        }

        public void SetUsedIdForNoteBook(List<NoteBook> noteBookList)
        {
            usedIdForNoteBook = noteBookList.Select(list => list.Id).ToList<int>();
        }

        public int SetIdForNote()
        {
            return GetLastId(usedIdForNote) + 1;
        }

        public int SetIdForNoteBook()
        {
            return GetLastId(usedIdForNoteBook) + 1;
        }

        public void RemoveIdNote(int Id)
        {
            usedIdForNote.Remove(Id);
        }

        public void RemoveIdNoteBook(int Id)
        {
            usedIdForNoteBook.Remove(Id);
        }

        private int GetLastId(List<int> usedId)
        {
            int LastId = 0;
            if (usedId.Count > 0)
            {
                LastId = usedId.Max();
            }
            return LastId;
        }
    }
}
