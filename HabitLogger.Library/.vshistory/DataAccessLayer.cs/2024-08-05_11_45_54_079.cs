using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Library
{
    internal class DataAccessLayer
    {
        private readonly string? connectionString = @"Data Source=habit-tracker.db";

        public DataAccessLayer()
        {
            SQLitePCL.Batteries.Init();
        }

        public void ExecuteNonQuery(string command)
        {
            using(var connection = new SqliteConnection(connectionString))
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
