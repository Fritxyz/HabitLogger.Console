using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Library
{
    public class HabitLoggerCrud
    {
        DataAccessLayer _layer = new DataAccessLayer();

        public void CreateTable()
        {
            string command = @"CREATE TABLE study_hours (
	                            Id	INTEGER NOT NULL,
	                            Date	TEXT NOT NULL,
	                            Quantity	INTEGER NOT NULL,
	                            PRIMARY KEY(Id AUTOINCREMENT)
                               );";

            _layer.ExecuteNonQuery(command);
        }
    }
}
