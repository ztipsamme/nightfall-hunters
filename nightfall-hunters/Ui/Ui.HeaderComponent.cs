using nightfall_hunters.classes;

namespace nightfall_hunters;

public static partial class Ui
{
    public static void HeaderComponent(Player player)
    {
        DrawBorderBlock(PositionBlock.Top, PrimaryColor);

        string title = "🌒  N I G H T F A L L   H U N T E R S   🌒";
        int titleLength = title.Length;
        
        int padding = (_uiWidth - titleLength) / 2;
        string leftPadding = new(' ', padding);
        string rightPadding = new(' ', _contentWidth - titleLength - padding);

        TextColor(PrimaryColor);
        Console.Write("║" + leftPadding);

        foreach (char c in title)
        {
            bool isHighlighted = c is 'N' or 'I' or 'E';
            TextColor(isHighlighted ? SecondaryColor : PrimaryColor);
            Console.Write(c);
        }
        
        Console.WriteLine(rightPadding + "║");

        if (player != null)
        {
            DrawBorderInline(new string('—', _contentWidth - _inlinePadding),
                foregroundColor: NeutralColor, borderColor: PrimaryColor);
            DrawBorderInline(player.Info(), alignment: Alignment.Center, borderColor: PrimaryColor);
        }
        
        DrawBorderBlock(PositionBlock.Bottom, PrimaryColor);
        DrawDivider();
    }
    
}