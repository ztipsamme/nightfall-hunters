namespace nightfall_hunters;

public partial class Ui
{
    public static void TextColor() => Console.ResetColor();

    public static void TextColor(ConsoleColor color) =>
        Console.ForegroundColor = color;
    
    private static void AlignText(string text, Alignment alignment)
    {
        string line = new(' ', _contentWidth - text.Length);
        int textAlign = alignment switch
        {
            Alignment.Left => _padding,
            Alignment.Right => line.Length,
            Alignment.Center => (int)Math.Floor(line.Length / 2.0),
        };

        Console.Write(line.Insert(textAlign, text));
    }
}