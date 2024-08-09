using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
