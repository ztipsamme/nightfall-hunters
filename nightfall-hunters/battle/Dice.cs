namespace nightfall_hunters.classes;

public class Dice
{
    private static Random rng = new Random();
    public static int Roll(int sides = 8)
    {
        return rng.Next(1, sides + 1);
    }
}