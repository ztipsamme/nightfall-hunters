using nightfall_hunters.classes;
using nightfall_hunters.ui;

namespace nightfall_hunters.game;

public class GameIntro
{
    public static void Run(Player player)
    {
        player.CreateCharacter();
        
        Display.ClearBody(3);
        
        Display.DrawHeader(player);
        
        StoryNode? introNode = StoryNode.GetNode("Intro");
        
        introNode?.Show(player);
        Display.DrawSpacer();

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}