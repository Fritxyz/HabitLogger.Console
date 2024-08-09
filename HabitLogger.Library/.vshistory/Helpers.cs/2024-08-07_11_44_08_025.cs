using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Library
{
    internal static class Helpers
    {
        internal static string? _getDateStr;

        internal static void ShowTable(this DataTable dataTable)
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
                    row["Quantity"].ToString()!
                );
            }


            AnsiConsole.Write(table);
        }

        internal static bool EnterDatePrompt()
        {
            bool isDateParsed = false;

            do
            {
                Console.Write("Enter a date (mm-dd-yyyy) or enter '0' to back into the menu: ");
                string? dateStrInput = Console.ReadLine();

                if (dateStrInput == "0")
                    break;

                isDateParsed = DateOnly.TryParseExact(dateStrInput, "MM-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly date);

                _getDateStr = Convert.ToString(date)!;

                if (!isDateParsed)
                    Console.WriteLine("Invalid Date\n");
            } while (!isDateParsed);

            return isDateParsed;
        }
       
    }
}
