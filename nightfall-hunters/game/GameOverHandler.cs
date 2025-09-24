using nightfall_hunters.classes;
using nightfall_hunters.helpers;

namespace nightfall_hunters.game;

public class GameOverHandler
{
    public static void Handle(ref Player player)
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
        Quit(player);
    }
    
    public static void Quit(Player player)
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
}