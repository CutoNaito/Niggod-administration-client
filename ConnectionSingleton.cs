using MySql.Data.MySqlClient;

namespace Niggod_admin_client;

public class ConnectionSingleton
{
    private static MySqlConnection conn;

    private ConnectionSingleton()
    {
    }

    public static MySqlConnection GetConnection()
    {
        conn = new MySqlConnection("Database=niggod;Data Source=localhost;User Id=root;Password=");
        conn.Open();
        return conn;
    }

    public static void CloseConnection()
    {
        conn.Close();
        conn.Dispose();
    }
}