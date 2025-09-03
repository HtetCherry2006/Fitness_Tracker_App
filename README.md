# Fitness_Tracker_App


## Overview
Fitness Tracker App is a C# Windows Forms application that allows users to register, log their fitness activities, and track progress in a simple desktop interface.

## Features
- User registration and login
- Add new fitness activities
- View past activities and track progress
- Integrated database connection
- Clean user interface with multiple forms

## Requirements
- Visual Studio (2019 or later recommended)
- .NET Framework 4.7.2 or compatible
- SQL Server (or LocalDB for database connection)

## Installation
1. Open the `Fitness_Tracker.sln` file in Visual Studio.
2. Restore NuGet packages if needed (`packages.config` is included).
3. Build the solution.
4. Run the project (F5).

## Usage
1. Register as a new user.
2. Log in with your credentials.
3. Add fitness activities such as running, cycling, or gym workouts.
4. Track your progress from the main form.
5. Exit the app gracefully with the goodbye screen.

## Project Structure
- `Program.cs` - Entry point of the application
- `Form1.cs` - Login form
- `Register Form.cs` - User registration form
- `Main Form.cs` - Dashboard for managing activities
- `Add_Activity.cs` - Add new fitness activity
- `DatabaseConnection.cs` - Handles database connectivity
- `Activity.cs` - Activity model class

Author 
Htet Htet Aung
## Author
Created as a practice project to learn C# Windows Forms, database handling, and desktop app development.
