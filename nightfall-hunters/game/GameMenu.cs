using nightfall_hunters.classes;
using nightfall_hunters.helpers;
using Nightfall_Hunters.quests;
using nightfall_hunters.ui;

namespace nightfall_hunters.game;

public class GameMenu
{
    public static void Show(Player player)
    {
        List<MenuItem> mainMenu = new List<MenuItem>{
           new ("Play Quest"),
           new ("Heal"),
           new ("Status"),
           new ("Quit", "q")
        };
        
        Display.DrawCenterText("Main Menu");
        Display.DrawSpacer();

        var selected = InputHelper.ShowMenu("Select an option:", mainMenu);
        
        ui.Display.ClearBody();
        Display.DrawSpacer();
            
        switch (selected)
        {
            case "1":
                PlayQuest.Start(player);
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
                GameOverHandler.Quit(player);
                break;
        }
    }
}