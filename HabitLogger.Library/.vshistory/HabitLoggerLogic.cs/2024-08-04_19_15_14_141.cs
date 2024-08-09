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
                Console.WriteLine("Invalid number");
            }
            else
            {
                switch (inputNum)
                {
                    case 0:
                        Console.WriteLine("\nExit the application\n");
                        isEnd = true;
                        break;
                    case 1:
                        Console.WriteLine("View Data");
                        isEnd = false;
                        break;
                    case 2:
                        Console.WriteLine("Insert Data");
                        isEnd = false;
                        break;
                    case 3:
                        Console.WriteLine("Delete Data");
                        isEnd = false;
                        break;
                    case 4:
                        Console.WriteLine("Update Data");
                        isEnd = false;
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        isEnd = false;
                        break;
                }
            }

            return isEnd;
        }
    }
}
