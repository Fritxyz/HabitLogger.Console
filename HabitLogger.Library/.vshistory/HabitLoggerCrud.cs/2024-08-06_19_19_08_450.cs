using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SQLite;

namespace HabitLogger.Library
{
    public static class HabitLoggerCrud
    {
        private static DataAccessLayer _layer = new DataAccessLayer();

        #region CreateTable
        public static void CreateTable()
        {
            string command = @"CREATE TABLE IF NOT EXISTS study_hours (
	                            Id INTEGER NOT NULL,
	                            Date TEXT NOT NULL,
	                            Quantity INTEGER NOT NULL,
	                            PRIMARY KEY(Id AUTOINCREMENT)
                               );";

            _layer.ExecuteNonQuery(command);
        }
        #endregion

        #region InsertData
        public static bool InsertData(string date, int quantity)
        {
            bool isSuccess = false; 
            string? command = $@"INSERT INTO study_hours (Date, Quantity) 
                                VALUES ('{date}', {quantity});";

            try
            {
                _layer.ExecuteNonQuery(command);
                isSuccess = true;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to insert data");
                throw;
            }
            
            return isSuccess;
        }
        #endregion

        #region ViewAllData
        public static void ViewAllData()
        {
            string? command = @"SELECT * FROM study_hours";

            DataTable data = _layer.ExecuteQuery(command);

            data.ShowTable();
        }
        #endregion

        public static void GetDataByDate(string? date)
        {
            string? command = $@"SELECT * FROM study_hours WHERE Date=@date";

            DataTable dataTable = _layer.ExecuteQuery(command, new SQLiteParameter("@date"));

            if(dataTable == null)
                Console.WriteLine("Null");
            else
                Console.WriteLine("Has Values");
        }
    }
}
