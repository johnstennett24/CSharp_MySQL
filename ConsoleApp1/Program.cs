using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1;
/// <summary>
/// This file contains the main function for the program
/// </summary>

public static class Program
{
  private static void Main()
  {
    var db = new DatabaseServices();
    db.OpenConnection();
    var isRunning = true;

    while (isRunning)
    {
      Display();
      var choice = Console.ReadLine();
      switch (choice)
      {
        case "1":
          db.ShowActorsFirstName();
          break;
        case "2":
          db.ShowActorsLastName();
          break;
        case "3":
          db.ShowActorFullname();
          break;
        case "4":
          db.GetAName();
          break;
        default:
          isRunning = false;
          break;
      }
    }

    db.CloseConnection();
  }
  /// <summary>
  /// The display method works to display the menu for the program.
  /// </summary>
  private static void Display()
  {
    Console.WriteLine("1. Show Actor First Names");
    Console.WriteLine("2. Show Actor Last Names");
    Console.WriteLine("3. Show Actor Full Name");
    Console.WriteLine("4. Show Unique Actor Full Name");
    Console.WriteLine("5. Quit");
    Console.Write("choice: ");
  }
}