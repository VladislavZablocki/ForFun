using System;
using System.Collections.Generic;
using System.Linq;

namespace NotePad
{
    /// <summary>
    /// Class of entity notebook. Contains list of notes.
    /// </summary>
    public class NoteBook
    {

        private List<Note> noteList = new List<Note>();
        public string Author { get;private set; }
        public int Id { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="author">authors name,default Vladislav </param>
        public NoteBook()
        {
        }

        /// <summary>
        /// Return list of notes
        /// </summary>
        /// <returns>list of notes</returns>
        public List<Note> GetNoteList()
        {
            return noteList;
        }

        /// <summary>
        /// Add new note to list
        /// </summary>
        /// <param name="content">string which </param>
        public void AddNote(string content)
        {
            Note note = new Note();
            noteList.Add(note);
        }


        /// <summary>
        /// Return note with necessary id
        /// </summary>
        /// <param name="id">id of note</param>
        /// <returns>note with necessary id</returns>
        public Note GetNoteById(int id)
        {
            Note note = new Note();
            foreach (var item in noteList)
            {
                if (item.Id == id)
                {
                    note = item;
                    break;
                }
            }
            return note;
        }

        /// <summary>
        /// Remove note from notebook and remove id from used id
        /// </summary>
        /// <param name="id">id of note</param>
        public void RemoveNote(int id)
        {
            foreach (var item in noteList)
            {
                if (item.Id == id)
                {
                    noteList.Remove(item);
                    break;
                }
            }
        }

        public override bool Equals(object obj)
        {
            NoteBook noteBook = obj as NoteBook;
            if (noteBook == null)
            {
                return false;
            }
            return noteList.SequenceEqual(noteBook.noteList);
        }

        public override string ToString()
        {
            return string.Concat("Author : ", Author, "\nNumber of all notes ", noteList.Count,"\n------------");
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (var items in noteList)
            {
                hashCode += items.GetHashCode();
            }
            return hashCode + Author.GetHashCode();
        }
    }
}
