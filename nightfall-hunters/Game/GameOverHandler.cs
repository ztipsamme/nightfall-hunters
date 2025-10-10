using nightfall_hunters;
using nightfall_hunters.classes;

namespace Nightfall_Hunters.Game;

public class GameOverHandler
{
    public static void Handle(ref Player player)
    {
        Console.WriteLine($"💀 GAME OVER. {player.Name} is dead.");

        bool res = Helper.AskUntilValid(
            "Would you like to start over and play again? (y/n): ",
            "Must enter 'y' or 'n'",
            input => input.ToLower() == "y" || input.ToLower() == "n",
            input => input.ToLower() == "y"
        );
        
        if (res)
        {
            player = null; // now reassigns the original variable
            Ui.LoadingAnimation("Restarting the game");
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
            
            res = Helper.AskUntilValid( 
                "Would you like to quit the game? (y/n): ", 
                "Must be 'y' or 'n'", 
                input =>  input.ToLower() == "y" || input.ToLower() == "n", 
                input => input );
        }
       
        
        if (res == "y" || player.Hp <= 0)
        {
            Console.WriteLine();
            Ui.DrawDivider();
            Console.WriteLine("Until next time brave hunter!");
            Ui.Continue("close the game");
            Environment.Exit(0);
        }
        
        Ui.DrawDivider();
        Ui.Continue("return to the Main Menu");
    }
}