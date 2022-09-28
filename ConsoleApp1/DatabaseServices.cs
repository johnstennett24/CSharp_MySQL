using MySql.Data.MySqlClient;
namespace ConsoleApp1;

public class DatabaseServices
{
  private readonly MySqlConnection _connection;

  public DatabaseServices()
  {
    var server = "127.0.0.1";
    var database = "sakila";
    var uid = "student";
    var password = "student";
    var connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" +
                           password + ";";
    
    _connection = new MySqlConnection(connectionString);
  }
  /// <summary>
  /// ShowActorsFirstName is used to display the actors first names in the database.
  /// </summary>
  public void ShowActorsFirstName()
  {
    MySqlCommand command = new MySqlCommand();
    command.CommandText = "select distinct first_name from actor order by first_name";
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
      string columnName = (string)reader["first_name"];
      Console.WriteLine(columnName);
    }
    reader.Close();
  }
  /// <summary>
  /// ShowActorsLastName is similar to ShowActorsFirstName except it shows the last name instead of the first name.
  /// </summary>

  public void ShowActorsLastName()
  {
    MySqlCommand command = new MySqlCommand();
    command.CommandText = "select distinct last_name from actor order by last_name";
    var reader = command.ExecuteReader();
    
    while (reader.Read())
    {
      string columnName = (string)reader["last_name"];
      Console.WriteLine(columnName);
    }
    reader.Close();
  }
  /// <summary>
  /// ShowActorFullName shows the first and last name of each actor in the table.
  /// </summary>

  public void ShowActorFullname()
  {
    MySqlCommand command = new MySqlCommand();
    
    command.CommandText = "select distinct first_name, last_name from actor";
    var reader = command.ExecuteReader();
    
    while (reader.Read())
    {
      string firstName = (string)reader["last_name"];
      var lastName = (string)reader["last_name"];
      Console.WriteLine($"{firstName} {lastName}");
    }
    reader.Close();
  }
  /// <summary>
  /// GetAName takes input from the user and then searches for the first name that the
  /// user inputted in the table and displays all the different actors with that first name.
  /// </summary>

  public void GetAName()
  {
    MySqlCommand command = new MySqlCommand();

    Console.Write("Enter the first name of the Actor: ");
    string name = Console.ReadLine();
    
    command.CommandText = "select distinct first_name, last_name from actor where first_name = @name";
    command.Parameters.AddWithValue("@name", name);
    command.Connection = _connection;
    command.Prepare();
    
    var reader = command.ExecuteReader();

    while (reader.Read())
    {
      var firstName = (string)reader["first_name"];
      var lastName = (string)reader["last_name"];
      Console.WriteLine($"{firstName} {lastName}");
    }
    reader.Close();
  }
  /// <summary>
  /// The OpenConnection method is used to Open the connection to the database.
  /// </summary>
  /// <returns>Returns true if the connection is open, if it is not open then it returns false and an error</returns>
  public bool OpenConnection()
  {
    try
    {
      _connection.Open();
      return true;
    }
    catch (MySqlException exception)
    {
      switch (exception.Number)
      {
        case 0:
          Console.WriteLine("Error Occured");
          return false;
      }
    }
    return false;
  }
  /// <summary>
  /// The CloseConnection method closes the connection to the database.
  /// </summary>
  /// <returns>Returns true if the connection is closed and then false if is not closed.</returns>
  public bool CloseConnection()
  {
    try
    {
      _connection.Close();
      return true;
    }
    catch (MySqlException exception)
    {
      switch (exception.Number)
      {
        case 0:
          Console.WriteLine("There was an error");
        return false;
      }
    }
  
    return false;
  }
}