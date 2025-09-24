using nightfall_hunters.classes;

namespace nightfall_hunters.game;

public class Heal
{
    public static void Start(Player player)
    {
        ui.Display.DrawCenterText("Heal");
        ui.Display.DrawSpacer();

        Console.WriteLine($"{player.Name} takes some time to heal...");
        player.Heal();

        ui.Display.DrawSpacer();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}