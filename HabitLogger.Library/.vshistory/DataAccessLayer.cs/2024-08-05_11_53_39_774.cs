using Microsoft.Data.Sqlite;
using SQLitePCL;
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
        private readonly string? connectionString = @"Data Source=habit-tracker.db";

        public void ExecuteNonQuery(string command)
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
