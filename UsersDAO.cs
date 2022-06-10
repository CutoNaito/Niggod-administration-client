using MySql.Data.MySqlClient;

namespace Niggod_admin_client;

public class UsersDAO
{
    public void UpdateUsername(string oldUsername, string newUsername)
    {
        MySqlConnection conn = ConnectionSingleton.GetConnection();

        MySqlCommand updateCommand =
            new MySqlCommand("UPDATE users SET username = @newUsername WHERE username = @oldUsername", conn);
        updateCommand.Parameters.AddWithValue("@oldUsername", oldUsername);
        updateCommand.Parameters.AddWithValue("@newUsername", newUsername);
        updateCommand.ExecuteNonQuery();
    }

    public void DeleteUser(string username)
    {
        MySqlConnection conn = ConnectionSingleton.GetConnection();

        MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM users WHERE username = @username", conn);
        deleteCommand.Parameters.AddWithValue("@username", username);
        deleteCommand.ExecuteNonQuery();
    }
}