# HabitLogger Console Application

This is a simple console application built with .NET 8, C#, and SQLite. It allows users to log and manage their study hours, with options to view, insert, update, and delete data. The Spectre.Console package is used for improved console output formatting.

## Features

- **View All Data**: Display all records in the study hours table.
- **Insert New Data**: Add a new entry for study hours on a specific date.
- **Update Data**: Modify an existing record.
- **Delete Data**: Remove a record from the database.
- **Spectre.Console Integration**: Enhanced table display in the console.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQLite](https://www.sqlite.org/index.html)
- [Spectre.Console](https://spectreconsole.net/) NuGet package

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/fritxyz/HabitLogger.git
   cd HabitLogger
   ```

2. Restore dependencies:

   ```bash
   dotnet restore
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

### Usage

When you run the application, you'll be presented with a menu:

1. **View All Data**: Displays all the logged study hours.
2. **Insert New Data**: Prompts you to enter the date and hours studied.
3. **Update Data**: Allows you to update a specific record.
4. **Delete Data**: Lets you delete a record by its ID.
5. **Exit**: Closes the application.

### Database

The application uses an SQLite database to store the data. The database file is located at:

```plaintext
D:\Programming Outputs\C# Academy\HabitLogger.Console\HabitLogger.Demo\habit-tracker.db
```

You can modify the connection string in the `DataAccessLayer` class if you wish to change the database location.

### Code Overview

- **Program.cs**: The entry point of the application. Contains the main menu loop.
- **DataAccessLayer.cs**: Handles database operations using SQLite.
- **HabitLoggerCrud.cs**: Contains methods to create, read, update, and delete records in the database.
- **HabitLoggerLogic.cs**: Contains the main logic for handling user input and performing actions.
- **Helpers.cs**: Utility methods for displaying tables and handling user input with Spectre.Console.

### Dependencies

- **.NET 8**
- **SQLite**
- **Spectre.Console**

### Contributing

Contributions are welcome! Please open an issue or submit a pull request.

### License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
