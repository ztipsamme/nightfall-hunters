using nightfall_hunters.classes;

namespace nightfall_hunters;

public static partial class Ui
{
    public static ConsoleColor PrimaryColor = ConsoleColor.DarkMagenta;
    public static ConsoleColor SecondaryColor = ConsoleColor.DarkYellow;
    public static ConsoleColor DangerColor = ConsoleColor.Red;
    public static ConsoleColor SuccessColor = ConsoleColor.Green;
    public static ConsoleColor NeutralColor = ConsoleColor.DarkGray;


    private static int _uiWidth = 80;
    private static int _padding = 2;
    private static int _inlinePadding = _padding * 2;
    private static int _contentWidth = _uiWidth - _padding;


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

    public static void Continue(string prompt = "continue")
    {
        DrawDivider();
        TextColor(PrimaryColor);
        Console.WriteLine($"(Press any key to {prompt}...)");
        Console.ReadKey();
        TextColor();
    }

    public static void DrawDivider(char separator = ' ')
    {
        Console.WriteLine(new string(separator, _uiWidth));
    }
}