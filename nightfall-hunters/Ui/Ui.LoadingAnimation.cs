namespace nightfall_hunters;

public partial class Ui
{
    public static void LoadingAnimation(string text = "Loading")
    {
        DateTime startTime = DateTime.Now;

        string str = $"⏳ {text}";
        TextColor(PrimaryColor);
        Console.Write(str);

        int startLine = GetStartLine;

        TextColor(SecondaryColor);
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
        
        TextColor();
    }
}