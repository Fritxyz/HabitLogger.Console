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
        #region ChoiceMade Method
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
                    #region View Data Case
                    case 1:
                        HabitLoggerCrud.ViewAllData();
                        
                        isEnd = false;
                        break;
                    #endregion
                    #region Insert Data Case
                    case 2:
                        Console.WriteLine("\nInserting Data");
                        Console.WriteLine("=====================================");
                        bool isDateParsed = false;
                        bool isQuantityParsed = false;

                        string? dateStr = default;
                        int quantity = default;

                        do
                        {
                            Console.Write("Enter a date (mm-dd-yyyy) or enter '0' to back into the menu: ");
                            string? dateStrInput = Console.ReadLine();

                            if (dateStrInput == "0")
                                break;

                            isDateParsed = DateOnly.TryParseExact(dateStrInput, "MM-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly date);

                            dateStr = Convert.ToString(date);

                            if (!isDateParsed)
                                Console.WriteLine("Invalid Date\n");
                        } while (!isDateParsed);
                        
                        if(isDateParsed)
                        {
                            do
                            {
                                Console.Write("\nEnter a hours studied or enter '0' to back into the menu: ");
                                string? quantityStr = Console.ReadLine();

                                if (quantityStr == "0")
                                    break;

                                isQuantityParsed = int.TryParse(quantityStr, out quantity);

                                if (!isQuantityParsed || quantity < 0)
                                    Console.WriteLine("Invalid Quantity");
                            } while (!isQuantityParsed || quantity < 0);
                        }

                        bool isInsertedSuccessfully = HabitLoggerCrud.InsertData(dateStr!, quantity);

                        if(isInsertedSuccessfully)
                            Console.WriteLine("\nInserted Data Successfully\n");

                        isEnd = false;
                        break;
                    #endregion
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
        #endregion
    }
}
