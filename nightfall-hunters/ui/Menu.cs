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

public class Menu
{
    public string Title { get; set; }
    public List<MenuItem> Options { get; set; }

    public Menu(string title, List<MenuItem> options)
    {
        Title = title;
        Options = options;
    }

    private void Display()
    {
        ui.Display.DrawCenterText(Title);
        for (int i = 0; i < Options.Count; i++)
        {
            var key = Options[i].HotKey ?? (i + 1).ToString();
            Console.WriteLine($"[{key}] {Options[i].Title}");
        }
    }

    public string UseMenu()
    {
        Display();

        var choice = InputHelper.AskUntilValid(
            "Enter option: ",
            $"Must be int between 1 and {Options.Count} or 'q'.",
            input => input.ToLower() == "q" || (int.TryParse(input, out int opt) && opt > 0 && opt <= Options.Count),
            input => input
        );

        return choice;
    }
}
