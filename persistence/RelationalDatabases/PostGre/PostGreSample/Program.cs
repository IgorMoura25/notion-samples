using Npgsql;

string connectionString = "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=pass123;";

// Create a connection to the database
using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
{
    try
    {
        // Open the database connection
        connection.Open();

        // Create and execute a SQL command
        string sql = @"SELECT * FROM public.""testtable;""";

        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
        {
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Process the data
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    // ...
                }
            }
        }
    }
    catch (NpgsqlException ex)
    {
        // Handle any exceptions that may occur during database operations
        Console.WriteLine("PostgreSQL Error: " + ex.Message);
    }
}