﻿using System;
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
        private static int _quantity, _id;

        #region ChoiceMade Method
        public static bool ChoiceMade(string input)
        {
            bool isEnd = false;
            bool isANum = int.TryParse(input, out int inputNum);

            if (!isANum)
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
                        Console.WriteLine("\n=====================================\n");
                        HabitLoggerCrud.ViewAllData();
                        Console.WriteLine("\n=====================================\n");

                        isEnd = false;
                        break;
                    #endregion
                    #region Insert Data Case
                    case 2:
                        Console.WriteLine("\n=====================================\n");

                        _isDateParsed = Helpers.EnterDatePrompt();
                        _dateStr = Helpers._getDateStr;

                        bool isInsertedSuccessfully = false;
                        _quantity = Helpers.EnterQuantityPrompt(_isDateParsed);

                        if (_quantity > 0)
                        {
                            isInsertedSuccessfully = HabitLoggerCrud.InsertData(_dateStr!, _quantity);
                        }

                        if (isInsertedSuccessfully)
                        {
                            Console.WriteLine("\nInserted Data Successfully");
                        }

                        Console.WriteLine("\n=====================================");

                        isEnd = false;
                        break;
                    #endregion
                    #region Delete Data Case
                    case 3:
                        Console.WriteLine("\n=====================================\n");

                        bool isDataDeleted = false;

                        HabitLoggerCrud.ViewAllData();

                        do
                        {
                            _id = Helpers.EnterIdPrompt();

                            if (_id == 0)
                            {
                                break;
                            }

                            isDataDeleted = HabitLoggerCrud.DeleteData(_id);

                            if (isDataDeleted)
                            {
                                Console.WriteLine("\nData deleted");
                            }
                            else
                            {
                                Console.WriteLine("\nNot deleted");
                            }

                            Console.WriteLine("\n=====================================");

                        } while (!isDataDeleted);

                        isEnd = false;
                        break;
                    #endregion
                    #region Update Data Case
                    case 4:
                        Console.WriteLine("\n=====================================\n");

                        HabitLoggerCrud.ViewAllData();

                        bool isDataUpdated = false;

                        _id = Helpers.EnterIdPrompt();

                        if (_id > 0)
                        {
                            Console.WriteLine();
                            _isDateParsed = Helpers.EnterDatePrompt();
                            _dateStr = Helpers._getDateStr;

                            _quantity = Helpers.EnterQuantityPrompt(_isDateParsed);

                            if (_quantity > 0)
                            {
                                isDataUpdated = HabitLoggerCrud.UpdateData(_id, _dateStr!, _quantity);

                                if (isDataUpdated)
                                {
                                    Console.WriteLine("\nData updated");
                                }
                                else
                                {
                                    Console.WriteLine("\nNot updated");
                                }
                            }
                        }

                        Console.WriteLine("\n=====================================");

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
