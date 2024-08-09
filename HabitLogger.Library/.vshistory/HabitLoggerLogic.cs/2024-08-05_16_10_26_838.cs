using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HabitLogger.Library
{
    public static class HabitLoggerLogic
    {
        public static bool ChoiceMade(string input)
        {
            int inputNum;
            bool isEnd = false;
            bool isANum = int.TryParse(input, out inputNum);

            if(!isANum)
            {
                Console.WriteLine("\nInvalid number");
            }
            else
            {
                switch (inputNum)
                {
                    case 0:
                        Console.WriteLine("\nExit the application");
                        isEnd = true;
                        break;
                    case 1:
                        Console.WriteLine("\nView Data");
                        isEnd = false;
                        break;
                    case 2:
                        Console.WriteLine("\nInsert Data");
                        bool isDateParsed = false;

                        do
                        {
                            Console.Write("Enter a date (mm-dd-yyyy) or enter '0' to back into the menu: ");
                            string? dateStr = Console.ReadLine();

                            if (dateStr == "0")
                                break;

                            isDateParsed = DateOnly.TryParseExact(dateStr, "MM-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly date);

                            if (!isDateParsed)
                                Console.WriteLine("Invalid Date\n");
                            else
                                Console.WriteLine("Success");
                        } while (!isDateParsed);
                       
                        isEnd = false;
                        break;
                    case 3:
                        Console.WriteLine("\nDelete Data");
                        isEnd = false;
                        break;
                    case 4:
                        Console.WriteLine("\nUpdate Data");
                        isEnd = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid number");
                        isEnd = false;
                        break;
                }
            }

            return isEnd;
        }
    }
}
