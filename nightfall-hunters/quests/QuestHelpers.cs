using System.Runtime.InteropServices.JavaScript;

namespace nightfall_hunters.classes;

public static class QuestHelpers
{
    static Random _rnd = new Random();

    static int AddNum(int a, int b)
    {
        return a + b;
    }

    static double GetSquare(int n)
    {
        return Math.Sqrt(n);
    }

    static int GetMi(int a, int b)
    {
        return Math.Min(a, b);
    }

    static int GetDiff(int a, int b)
    {
        return a - b;
    }

    static double GetCircleArea(int radius)
    {
        return Math.PI * radius * radius;
    }

    static void GuessNum(int n)
    {
        int num = _rnd.Next();

        while (true)
        {
            Console.Write("Enter your guess:");
            if(n < num) Console.WriteLine("Bigger");
            if(n > num) Console.WriteLine("Smaller");
            if(n == num)break;
        }
    }
    
    public record Gems(string Name, (int R, int G, int B) Rgb);

    private static Gems[] colors = 
    {
        new("ruby",        (224, 17, 95)),
        new("sapphire",    (15, 82, 186)),
        new("emerald",     (80, 200, 120)),
        new("citrine",     (228, 208, 10)),
        new("amethyst",    (153, 102, 204)),
        new("peridot",     (170, 225, 77)),
        new("aquamarine",  (127, 255, 212)),
        new("topaz",       (255, 200, 124))
    };

    static Gems[] GetThreeGems()
    {
        Gems[] str = new Gems[3];
        
        for (int i = 0; i < 3; i++)
        {
            int r = _rnd.Next();
            str[i] = colors[r];
        }

        return str;
    }
    
    
}