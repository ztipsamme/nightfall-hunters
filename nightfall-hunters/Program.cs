using nightfall_hunters.classes;
using nightfall_hunters.helpers;
using nightfall_hunters.ui;

namespace nightfall_hunters;

class Program
{
    public static string Title = "✨🗡️ Nightfall Hunters 🗡️✨";
    static bool _useMockData = true;
    
    static void Main(string[] args)
    {
        
        var player = _useMockData
            ? new Player("Emma", Gender.Female, Role.Archer)
            : new Player();

        while (true)
        {
            Console.Clear();
            Display.DrawHeader(player);

            if (string.IsNullOrEmpty(player.Name))
            {
                Intro(player);
                continue;
            }
            
            if (player.Hp <= 0)
            {
                GameOver(ref player);
                continue;
            }

            MainMenu(player);
        }
    }

    private static void MainMenu(Player player)
    {
        List<MenuItem> mainMenu = new List<MenuItem>{
                new MenuItem("Play Quest"),
                new MenuItem("Heal"),
                new MenuItem("Status"),
                new MenuItem("Quit", "q")
            };
        
        Display.DrawCenterText("Main ShowMenu");
        Display.DrawSpacer();

        var selected = InputHelper.ShowMenu("Select an option:", mainMenu);
        
        ui.Display.ClearBody();
        Display.DrawSpacer();
            
        switch (selected)
        {
            case "1":
                Display.DrawCenterText("Quest");
                Display.DrawSpacer();
                
                BattleSystem.Run(player, Enemy.GetRandomEnemy());
                break;
            case "2":
                Display.DrawCenterText("Heal");
                Display.DrawSpacer();
                
                Console.WriteLine($"{player.Name} takes some time to heal...");
                player.Heal();
                
                Display.DrawSpacer();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                break;
            case "q":
                QuitGame(player);
                break;
        }
    }
    
    private static void GameOver(ref Player player)
    {
        Console.WriteLine($"💀 GAME OVER. {player.Name} is dead.");

        bool res = InputHelper.AskUntilValid(
            "Would you like to start over and play again? (y/n): ",
            "Must enter 'y' or 'n'",
            input => input.ToLower() == "y" || input.ToLower() == "n",
            input => input.ToLower() == "y"
        );

        if (res)
        {
            player = new Player(); // now reassigns the original variable
            Console.WriteLine("Restarting the game...");
            Thread.Sleep(400);
            return;
        }

        Console.WriteLine();
        QuitGame(player);
    }

    private static void QuitGame(Player player)
    {
        string res = "";
        
        if (player.Hp > 0)
        {
            
            res = InputHelper.AskUntilValid( 
                "Would you like to quit the game? (y/n): ", 
                "Must be 'y' or 'n'", 
                input =>  input.ToLower() == "y" || input.ToLower() == "n", 
                input => input );
        }
       
        
        if (res == "y" || player.Hp <= 0)
        {
            Console.WriteLine();
            Console.WriteLine("Until next time brave hunter!");
            Console.WriteLine("Press any key to close the game...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        
        Console.WriteLine("\nPress any key to return to the Main ShowMenu...");
        Console.ReadKey();
    }

    private static void Intro(Player player)
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