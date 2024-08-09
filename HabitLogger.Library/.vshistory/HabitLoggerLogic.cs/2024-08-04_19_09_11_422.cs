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
        public static void ChoiceMade(string input)
        {
            int inputNum;
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
                        Console.WriteLine("Exit the application");
                        Process.GetCurrentProcess().Kill();
                        break;
                    case 1:
                        Console.WriteLine("View Data");
                        break;
                    case 2:
                        Console.WriteLine("Insert Data");
                        break;
                    case 3:
                        Console.WriteLine("Delete Data");
                        break;
                    case 4:
                        Console.WriteLine("Update Data");
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        break;
                }
            }
        }
    }
}
