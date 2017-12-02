using System;
using System.Collections.Generic;

namespace NotePad
{
    /// <summary>
    /// Class in charge of print the notebook to console 
    /// </summary>
    class NoteBookConsoleView
    {
        private NoteBook noteBook;
        private List<Note> noteList;
        
        public NoteBookConsoleView(NoteBook noteBook)
        {
            this.noteBook = noteBook;
            this.noteList = noteBook.GetNoteList();
        }
        
        /// <summary>
        /// Print all note in notebook
        /// </summary>
        public void Print()
        {
            Console.WriteLine(noteBook.ToString());
            foreach (var item in noteList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// print all note with necessary id
        /// </summary>
        /// <param name="id">array of id</param>
        public void Print(params int[] id)
        {
            Console.WriteLine("Author : {0}", noteBook.Author);
            foreach (int item in id)
            {
                Console.WriteLine(noteBook.GetNoteById(item).ToString());
            }
        }
    }
}
