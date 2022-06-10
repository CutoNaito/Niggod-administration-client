namespace Niggod_admin_client;

public class Menu
{
    private string caption { get; init; }
    private List<MenuItem> menuItems = new List<MenuItem>();

    public Menu(string capt)
    {
        caption = capt;
    }

    public MenuItem Selection()
    {
        string input = Console.ReadLine();
        int idInput;
        if (!int.TryParse(input, out idInput))
        {
            Console.Error.WriteLine($"Input {input} is not valid.");
            return null;
        }
        return Selection(idInput);
    }
    
    public MenuItem Selection(int input)
    {
        if (input - 1 < 0 || input - 1 >= menuItems.Count)
        {
            Console.Error.WriteLine($"Index {input} is not valid.");
            return null;
        }

        return menuItems[input - 1];
    }

    public MenuItem Execute()
    {
        MenuItem item = Selection();
        return item;
    }

    public void Add(MenuItem item)
    {
        menuItems.Add(item);
    }
}