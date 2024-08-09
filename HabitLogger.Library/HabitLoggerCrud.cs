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
        private static readonly DataAccessLayer _layer = new();

        #region CreateTable
        public static void CreateTable()
        {
            const string command = @"CREATE TABLE IF NOT EXISTS study_hours (
	                            Id INTEGER NOT NULL,
	                            Date TEXT NOT NULL,
	                            Quantity INTEGER NOT NULL,
	                            PRIMARY KEY(Id AUTOINCREMENT)
                               );";

            _layer.ExecuteNonQuery(command);
        }
        #endregion

        #region InsertData
        internal static bool InsertData(string date, int quantity)
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
        internal static void ViewAllData()
        {
            const string? command = "SELECT * FROM study_hours";

            DataTable data = _layer.ExecuteQuery(command);

            data.ShowTable();
        }
        #endregion

        #region DeleteData
        internal static bool DeleteData(int id)
        {
            const string command = "DELETE FROM study_hours WHERE Id=@id";

            DataTable dataTable = _layer.ExecuteQuery(command, new SQLiteParameter("@id", id));

            return dataTable.Rows.Count <= 0 || dataTable == null;
        }
        #endregion

        #region GetAllDAtaIds
        internal static List<int> GetAllDataIds()
        {
            const string command = "SELECT Id FROM study_hours";

            DataTable dataTable = _layer.ExecuteQuery(command);

            List<int> ids = dataTable.AsEnumerable()
                .Select(row => (int)Convert.ToInt64(row["Id"]))
                .ToList();

            return ids;
        }

        #endregion

        #region UpdateData
        internal static bool UpdateData(int id, string date, int quantity)
        {
            string command = @"UPDATE study_hours 
                                     SET Date=@date, Quantity=@quantity 
                                     WHERE Id=@id;";

            var updatedId = new SQLiteParameter("@id", id);
            var updatedDate = new SQLiteParameter("@date", date);
            var updatedQuantity = new SQLiteParameter("@quantity", quantity);

            _layer.ExecuteQuery(command, updatedId, updatedDate, updatedQuantity);

            command = @"SELECT * FROM study_hours
                        WHERE Id=@id AND Date=@date AND Quantity=@quantity";

            DataTable dataTable = _layer.ExecuteQuery(command, updatedId, updatedDate, updatedQuantity);

            int rowsAffected = dataTable.Rows.Count;

            return rowsAffected > 0;
        }
        #endregion
    }
}
