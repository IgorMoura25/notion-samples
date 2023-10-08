using Oracle.ManagedDataAccess.Client;

class Program
{
    static void Main()
    {
        // Replace these values with your Oracle database credentials
        string connectionString = "User Id=your_username;Password=your_password;Data Source=your_datasource;";

        try
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Connected to Oracle Database!");

                    string sql = @"SELECT * FROM public.""testtable;""";

                    using (OracleCommand command = new OracleCommand(sql, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
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

                    connection.Close();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
