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
            Alignment.Center => line.Length / 2,
        };

        Console.Write(line.Insert(textAlign, text));
    }

    public static void Header(string text, ConsoleColor? borderColor = null)
    {
        ConsoleColor color = borderColor ?? NeutralColor;
            
        int length = (_contentWidth - text.Length) / 2;
        string line = new('═', length);

        TextColor(color);
        Console.Write(line);
        
        TextColor();
        Console.Write($" {text} ");
        
        TextColor(color);
        Console.WriteLine(line);
        TextColor();
    }
}