namespace nightfall_hunters;

public partial class Ui
{
    private const ConsoleColor BorderColor = ConsoleColor.DarkGray;

    public static void BorderComponent(Action content)
    {
        List<string> lines = new();
        var originalOut = Console.Out;

        try
        {
            using (var writer = new System.IO.StringWriter())
            {
                Console.SetOut(writer);
                content(); // Run inner content
                writer.Flush();
                lines.AddRange(writer.ToString()
                    .Split(new[] { Environment.NewLine },
                        StringSplitOptions.RemoveEmptyEntries));
            }
        }
        finally
        {
            Console.SetOut(originalOut);
        }

        List<string> formatedLines = new();

        for (int i = 0; i < lines.Count; i++)
        {
            string line = lines[i];

            if (line.Length > _contentWidth)
            {
                for (int j = 0; j < line.Length; j += _contentWidth)
                {
                    int length = Math.Min(_contentWidth, line.Length - j);
                    formatedLines.Add(line.Substring(j, length));
                }
            }
            else formatedLines.Add(line);
        }

        DrawBorderBlock(PositionBlock.Top);

        foreach (string line in formatedLines)
        {
            DrawBorderInline(line);
        }

        DrawBorderBlock(PositionBlock.Bottom);
    }

    public static void DrawBorderBlock(PositionBlock position,
        ConsoleColor borderColor = BorderColor)
    {
        string line = new('═', _contentWidth);
        string top = "╔" + line + "╗";
        string bottom = "╚" + line + "╝";

        TextColor(borderColor);
        Console.WriteLine(position == PositionBlock.Top ? top : bottom);
        TextColor();
    }

    public static void DrawBorderInline(string text,
        Alignment alignment = Alignment.Left,
        ConsoleColor foregroundColor = ConsoleColor.White,
        ConsoleColor borderColor = BorderColor)
    {
        TextColor(borderColor);
        Console.Write("║");

        TextColor(foregroundColor);
        AlignText(text, alignment);

        TextColor(borderColor);
        Console.Write("║");
        TextColor();
        Console.SetCursorPosition(0, GetStartLine + 1);
    }
}