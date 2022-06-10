using MySql.Data.MySqlClient;

namespace Niggod_admin_client;

public class ConsoleDB
{
    public void Start()
    {
        try
        {
            MainMenu();
        }
        catch (MySqlException)
        {
            Console.WriteLine("Cannot access MySql Database");
        }
    }

    public void MainMenu()
    {
        Menu menu = new Menu("Select one option: ");
        menu.Add(new MenuItem("1. Manage users", () =>
            {
                var m = MenuUsers();
                var item = m.Execute();
                item.Execute();
            }
            ));
        menu.Add(new MenuItem("2. Manage posts", () =>
            {
                var m = MenuPost();
                var item = m.Execute();
                item.Execute();
            }
            ));
        menu.Add(new MenuItem("Exit program", () => { exit = true; }));

        while (!exit)
        {
            var item = menu.Execute();
            item.Execute();
        }
    }

    private bool exit = false;

    private Menu MenuUsers()
    {
        Menu m = new Menu("Type a username of a user you want to manage: ");
        string username = Console.ReadLine();
        UsersDAO usersDAO = new UsersDAO();
        m.Add(new MenuItem("1. Update username: ", () =>
        {
            Console.WriteLine("Type a new username: ");
            string newUsername = Console.ReadLine();
            usersDAO.UpdateUsername(username, newUsername);
        }));
        m.Add(new MenuItem("2. Delete username: ", () =>
        {
            usersDAO.DeleteUser(username);
        }));
        return m;
    }

    private Menu MenuPost()
    {
        Menu m = new Menu("Type an id of a post you want to manage: ");
        string id = Console.ReadLine();
        int idx;
        if (int.TryParse(id, out idx))
        {
            PostDAO postDAO = new PostDAO();
            m.Add(new MenuItem("1. Delete post: ", () =>
            {
                postDAO.DeletePost(idx);
            }));
            m.Add(new MenuItem("2. Update text content: ", () =>
            {
                Console.WriteLine("Type new text content: ");
                string newContent = Console.ReadLine();
                postDAO.UpdateText(newContent, idx);
            }));
            m.Add(new MenuItem("3. Delete image from a post: ", () =>
            {
                postDAO.RemoveImage(idx);
            }));
        }
        else
        {
            Console.Error.WriteLine($"Input {id} is not valid");
        }

        return m;
    }
}