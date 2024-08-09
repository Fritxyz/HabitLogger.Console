using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Library
{
    internal static class Helpers
    {
        internal static void ShowTable(DataTable dataTable)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Date");
            table.AddColumn("Hours Studied (Qty.)");

            foreach (DataRow row in dataTable.Rows)
            {
                table.AddRow(
                    row["Id"].ToString()!, 
                    row["Date"].ToString()!,
                    row["Qty"].ToString()!
                );
            }
        }
    }
}
