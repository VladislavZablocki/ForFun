using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace NotePad
{
    class DAOSQL : INoteBookDAO
    {
        private string connectionString = @"Data Source=WINCTRL-I06LHQ3;Initial Catalog=NotePadBD;Integrated Security=True";
        private NoteBook currentNoteBook = new NoteBook();

        public  void OpenNoteBook()
        {
            throw new NotImplementedException();
        }

        public  void SaveNoteBook()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandString = "INSERT INTO Note(Note_Title,DateAndTime,[Content],Note_Author,Id_NoteBook) VALUES(@param1,@param2,@param3,@param4,@param5)";
                foreach (var item in currentNoteBook.GetNoteList())
                {
                    SqlCommand commandSQL = new SqlCommand(commandString, connection);
                    connection.Open();
                    commandSQL.Parameters.AddWithValue("@param1", item.Title);
                    commandSQL.Parameters.AddWithValue("@param2", item.Date);
                    commandSQL.Parameters.AddWithValue("@param3", item.Content);
                    commandSQL.Parameters.AddWithValue("@param4", item.Author);
                    commandSQL.Parameters.AddWithValue("@param5", currentNoteBook.Id);
                    commandSQL.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
