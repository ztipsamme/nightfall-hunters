using nightfall_hunters.helpers;
namespace nightfall_hunters.ui;


public class MenuItem
{
    public string Title { get; set; }
    public string? HotKey { get; set; }

    public MenuItem(string title, string? hotKey = null)
    {
        Title = title;
        HotKey = hotKey;
    }
}