using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Library
{
    internal class DataAccessLayer
    {
        private readonly string? connectionString = @"Data Source=D:\Programming Outputs\C# Academy\HabitLogger.Console\HabitLogger.Demo\habit-tracker.db";

        internal void ExecuteNonQuery(string command)
        {
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
