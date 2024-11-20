using System;
using Microsoft.Data.Sqlite;

class Program
{
    static void Main()
    {
        // Connection string for SQLite database
        string connectionString = "Data Source=/Users/your_username/Documents/Northwind.db";
        
        // Query to retrieve products where UnitPrice > 5
        string queryString = "SELECT ProductID, UnitPrice, ProductName " +
                             "FROM products " +
                             "WHERE UnitPrice > @pricePoint " +
                             "ORDER BY UnitPrice DESC;";

        int paramValue = 5;

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(queryString, connection))
            {
                // Add parameter value
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                using (var reader = command.ExecuteReader())
                {
                    // Read and display the results
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", reader["ProductID"], reader["UnitPrice"], reader["ProductName"]);
                    }
                }
            }
        }

        Console.WriteLine("Query executed successfully. Press any key to exit...");
        Console.ReadKey();
    }
}

