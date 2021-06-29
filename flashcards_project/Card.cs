using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_interface
{
    /// <summary>
    /// This class stores question and answer values for each flashcard
    /// </summary>
    public class Card
    {
        private int id;
        private string _front;
        private string _back;

        public string Front
        {
            get { return _front; }
            set { _front = value; }
        }

        public string Back
        {
            get { return _back; }
            set { _back = value; }
        }
        public Card()
        {
            _front = "";
            _back = "";
        }

        public Card(int id, string front, string back)
        {
            this.id = id;
            _front = front;
            _back = back;
        }

        public void UpdateFront(string newFront)
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                cmd.CommandText = @"UPDATE cards SET Front = @front WHERE Id = @id";

                cmd.Parameters.AddWithValue("@front", newFront);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateBack(string newBack)
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                cmd.CommandText = @"UPDATE cards SET Back = @back WHERE Id = @id";

                cmd.Parameters.AddWithValue("@back", newBack);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                var cmd = new SQLiteCommand(Database.dbConnection);

                cmd.CommandText = @"DELETE FROM categories WHERE Id = @id";

                cmd.Parameters.AddWithValue("@id", Id);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        public override string ToString()
        {
            return ("Q:" +_front + " A:" + _back);
        }
    }
}
