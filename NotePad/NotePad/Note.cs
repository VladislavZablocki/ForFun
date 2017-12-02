using System;
using Newtonsoft.Json;

namespace NotePad
{
    /// <summary>
    /// Class of entity note. Contains next fields : ID, content of note, title, date an time of note
    /// </summary>
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }

        public Note()
        { }

        /// <summary>
        /// Create note with parameters from console
        /// </summary>
        /// <param name="content">string from console</param>
        /// <returns>new note</returns>
        public Note CreateNote(string title, string author, string content)
        {
            Title = title;
            Author = author;
            Content = content;
            Date = DateTime.Now;
            return this;
        }

        public override bool Equals(object obj)
        {
            Note note = obj as Note;
            if (note == null)
            {
                return false;
            }
            return (Content.Equals(note.Content));
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Title.GetHashCode() + Content.GetHashCode() + Date.GetHashCode();
        }

        public override string ToString()
        {
            return string.Concat("Id : ", Id, "\nAuthor", Author, "\nDate and time :", Date.ToString("dd.MM.yyyy H:m:s"),
                "\nTitle : ", Title, "\nText : ", Content, "\n");
        }

        public string NoteToJsonString()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public static Note JsonStringToNote(string json)
        {
            Note note = JsonConvert.DeserializeObject<Note>(json);
            return note;
        }
    }
}
