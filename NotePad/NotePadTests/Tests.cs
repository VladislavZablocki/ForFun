using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotePad;

namespace NotePadTests
{


    [TestClass]
    public class Tests
    {
        string date = DateTime.Now.ToString("dd.MM.yyyy");
        Note note1 = new Note(1, "a", "a");
        Note note2 = new Note(2, "b", "b");
        Note note3 = new Note(3, "b", "b");
        NoteBook noteBook = new NoteBook();

        [TestMethod]
        public void NoteEquals_DiffeterntNote_False()
        {
            bool expected = false;
            bool actual = note1.Equals(note2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoteEquals_SameNotes_True()
        {
            bool expected = true;
            bool actual = note2.Equals(note3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoteBook_RemoveNote_CountElementsInList()
        {
 
        }
    }
}
