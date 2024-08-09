using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Library
{
    public class DataAccessLayer
    {
        public static void ExecuteNonQuery(string command)
        {
            string? connectionString = @"Data Source=habit-tracker.db";

            using(var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                var tableCommand = connection.CreateCommand();

                tableCommand.CommandText = command;

                tableCommand.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
