using HabitLogger.Library;

Console.WriteLine("MAIN MENU\n");

Console.WriteLine("\nWhat would you like to do?\n");

Console.WriteLine("Type 0 to close the application");
Console.WriteLine("Type 1 to view all of the data");
Console.WriteLine("Type 2 to insert a new data");
Console.WriteLine("Type 3 to delete the data");
Console.WriteLine("Type 4 to update the data\n");

while (true)
{
    Console.Write("\nType a number: ");
    string? input = Console.ReadLine();
    HabitLoggerLogic.ChoiceMade(input!);
}


// call the Choice() method


Console.ReadKey();