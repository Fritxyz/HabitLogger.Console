using System;
using System.Collections.Generic;
using System.Data;
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

        internal DataTable ExecuteQuery(string command, params SQLiteParameter[] parameters)
        {
            DataTable dataTable = new();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using(var sqliteCommand = new SQLiteCommand(command, connection)) 
                {
                    sqliteCommand.Parameters.AddRange(parameters);

                    using (var adapter =  new SQLiteDataAdapter(sqliteCommand))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}
