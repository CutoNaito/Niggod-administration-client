namespace Niggod_admin_client;

public class MenuItem
{
    private string desc;
    private Action action;

    public MenuItem(string description, Action act)
    {
        desc = description;
        action = act;
    }

    public override string ToString()
    {
        return desc;
    }

    public void Execute()
    {
        action();
    }
}