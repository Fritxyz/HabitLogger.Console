using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace HabitLogger.Library
{
    public static class HabitLoggerLogic
    {
        private static bool _isDateParsed;
        private static string? _dateStr;
        private static int _quantity;

        #region ChoiceMade Method
        public static bool ChoiceMade(string input)
        {
            bool isEnd = false;
            bool isANum = int.TryParse(input, out int inputNum);

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

                        _isDateParsed = Helpers.EnterDatePrompt();
                        _dateStr = Helpers._getDateStr;

                        bool isInsertedSuccessfully = false;
                        _quantity = Helpers.EnterQuantityPrompt(_isDateParsed);

                        if (_quantity != 0)
                        {
                            isInsertedSuccessfully = HabitLoggerCrud.InsertData(_dateStr!, _quantity);
                        }

                        if(isInsertedSuccessfully)
                        {
                            Console.WriteLine("\nInserted Data Successfully");
                        }

                        isEnd = false;
                        break;
                    #endregion
                    #region Delete Data Case
                    case 3:
                        Console.WriteLine("\nDelete Data");
                        Console.WriteLine("=====================================");

                        bool isDataDeleted = false;
                        
                        // call the get all data
                        HabitLoggerCrud.ViewAllData();

                        do
                        {
                            int id = Helpers.EnterIdPrompt();

                            if (id == 0)
                                break;

                            isDataDeleted = HabitLoggerCrud.DeleteData(id);

                            if (isDataDeleted)
                            {
                                Console.WriteLine("Data deleted");
                            }
                            else
                            {
                                Console.WriteLine("Not deleted");
                            }
                        } while (!isDataDeleted);

                        isEnd = false;
                        break;
                    #endregion
                    #region Update Data Case
                    case 4:
                        Console.WriteLine("\nUpdate Data");
                        Console.WriteLine("=====================================");

                        // call the get all data
                        HabitLoggerCrud.ViewAllData();

                        bool isDataUpdated = false;

                        do
                        {
                            int id = Helpers.EnterIdPrompt();

                            if (id != 0)
                            {
                                _isDateParsed = Helpers.EnterDatePrompt();
                                _dateStr = Helpers._getDateStr;

                                _quantity = Helpers.EnterQuantityPrompt(_isDateParsed);

                                if (_quantity != 0)
                                {

                                    isDataUpdated = HabitLoggerCrud.UpdateData(id, _dateStr!, _quantity);

                                    if (isDataUpdated)
                                    {
                                        Console.WriteLine("Data updated");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not updated");
                                    }
                                }
                            }

                            

                        } while (!isDataUpdated);

                        isEnd = false;
                        break;
                    #endregion
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
