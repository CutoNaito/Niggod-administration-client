using MySql.Data.MySqlClient;

namespace Niggod_admin_client;

public class PostDAO
{
    public void DeletePost(int id)
    {
        MySqlConnection conn = ConnectionSingleton.GetConnection();

        MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM post WHERE id = @id", conn);
        deleteCommand.Parameters.AddWithValue("@id", id);
        deleteCommand.ExecuteNonQuery();
    }

    public void UpdateText(string content, int id)
    {
        MySqlConnection conn = ConnectionSingleton.GetConnection();

        MySqlCommand updateCommand = new MySqlCommand("UPDATE post SET text_content = @content WHERE id = @id", conn);
        updateCommand.Parameters.AddWithValue("@content", content);
        updateCommand.Parameters.AddWithValue("@id", id);
        updateCommand.ExecuteNonQuery();
    }

    public void RemoveImage(int id)
    {
        MySqlConnection conn = ConnectionSingleton.GetConnection();

        MySqlCommand deleteImageCommand =
            new MySqlCommand("UPDATE post SET image_content = @image WHERE id = @id", conn);
        deleteImageCommand.Parameters.AddWithValue("@image", "");
        deleteImageCommand.Parameters.AddWithValue("@id", id);
        deleteImageCommand.ExecuteNonQuery();
    }
}