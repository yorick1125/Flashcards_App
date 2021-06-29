using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace project_interface
{
    public static class Database
    {
        /// <summary>
        /// Getter for the database connection
        /// </summary>
        public static SQLiteConnection dbConnection
        {
            get; private set;
        }

        /// <summary>
        /// Opens the connection to the database
        /// </summary>
        /// <param name="databaseFile">The filename of the database file</param>
        public static void openExistingDatabase(string databaseFile)
        {
            try
            {
                if (!File.Exists(databaseFile))
                    throw new FileNotFoundException("File does not exist");
                string databasePath = $"Data Source={databaseFile}; Foreign Keys=1";

                dbConnection = new SQLiteConnection(databasePath);
                dbConnection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Creates a new database, opens the connection to it and creates a Expense table, a CategoryType table and a 
        /// Category table. It also directly populates the CategoryType table by using the Category.CategoryType enum
        /// </summary>
        /// <param name="databaseFile">The name of the database file to be created</param>
        public static void newDatabase(string databaseFile)
        {
            try
            {
                string databasePath = $"Data Source={databaseFile}; Foreign Keys=1";
                if (!File.Exists(databaseFile))
                {
                    SQLiteConnection.CreateFile(databaseFile);
                }

                dbConnection = new SQLiteConnection(databasePath);
                dbConnection.Open();

                var cmd = new SQLiteCommand(dbConnection);

                //Tables dropped in this order to avoid Foreign Key Constraint errors
                cmd.CommandText = @"DROP TABLE IF EXISTS decks; DROP TABLE IF EXISTS cards;";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE decks(Id INTEGER PRIMARY KEY, Name TEXT)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"CREATE TABLE cards(Id INTEGER PRIMARY KEY, Front TEXT, Back TEXT, DeckId INTEGER, FOREIGN KEY (DeckId) REFERENCES decks(Id))";
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Closes the database connection.
        /// </summary>
        static public void CloseDatabaseAndReleaseFile()
        {
            if (Database.dbConnection != null)
            {
                // close the database connection
                Database.dbConnection.Close();

                // wait for the garbage collector to remove the
                // lock from the database file
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
