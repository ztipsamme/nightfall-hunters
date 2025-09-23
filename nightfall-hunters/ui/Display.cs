using nightfall_hunters.classes;

namespace nightfall_hunters.ui;

public static class Display
{
    public static void DrawHeader(Player player)
    {
        Console.SetCursorPosition(0, 0);
        DrawCenterText(Program.Title);
        DrawSpacer();
        
        if (!string.IsNullOrEmpty(player.Name))
        {
            DrawCenterText(player.Status(), ' ');
            DrawSpacer();
        }
        
        DrawDevider();
        DrawSpacer();
    }

    public static void DrawCenterText(string title, char character = '=')
    {
        string line = new string(character, Console.WindowWidth);
        string temp = line.Substring(0, line.Length - title.Length - 2);
            
        int middleIndex = (int)Math.Floor(temp.Length / 2.0);
        
        Console.WriteLine(temp.Insert(middleIndex, $" {title} "));
    }

    public static void DrawDevider() =>
        Console.WriteLine(new string('-', Console.WindowWidth));
    
    public static void DrawSpacer () => Console.WriteLine();

    public static void ClearBody(int leveTopRows = 5)
    {
        int headerHeight = leveTopRows;
        
        for (int i = headerHeight; i < Console.WindowWidth; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(new string(' ', Console.WindowWidth));
        }
        
        Console.SetCursorPosition(0, headerHeight);
    }
}