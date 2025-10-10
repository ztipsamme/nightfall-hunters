using nightfall_hunters.classes;

namespace nightfall_hunters;

public static class Ui
{
    // Place above Console.WriteLine and below Console.Write
    public static int GetStartLine => Console.GetCursorPosition().Top;

    public static void Clear(int startLine = 0)
    {
        for (int i = startLine; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        Console.SetCursorPosition(0, startLine);
    }

    public static void DrawHeader(string text, char separator = '=')
    {
        string line = new(separator, Console.WindowWidth - text.Length - 2);

        Console.WriteLine(line.Insert(3, $" {text} "));
    }

    public static void DrawDivider(char separator = ' ') =>
        Console.WriteLine(new string(separator, Console.WindowWidth));

    public static void Continue(string prompt = "continue")
    {
        DrawDivider();
        Console.WriteLine($"(Press any key to {prompt}...)");
        Console.ReadKey();
    }

    public static void LoadingAnimation(string text = "Loading")
    {
        DateTime startTime = DateTime.Now;

        string str = $"⏳ {text}";
        Console.Write(str);

        int startLine = GetStartLine;

        while ((DateTime.Now - startTime).TotalMilliseconds <= 800)
        {
            // Clear dots
            Console.SetCursorPosition(str.Length, startLine);
            Console.Write(new string(' ', 3));

            // Draw dots
            Console.SetCursorPosition(str.Length, startLine);
            for (int j = 0; j < 3; j++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }
        }
    }

    public static void HeaderComponent(Player player)
    {
        DrawHeader("✨ Nightfall Hunters ✨");

        if (player != null)
        {
            DrawDivider();
            Console.WriteLine(player.Info());
            DrawDivider();
            DrawDivider('=');
        }
        DrawDivider();
    }
}