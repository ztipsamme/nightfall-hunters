using nightfall_hunters.ui;

namespace nightfall_hunters.classes;

public class BattleActions
{
    public static void Execute(string? choice, Player player, Enemy enemy)
    {
        switch (choice)
        {
            case "1":
                player.Attack(enemy);
                break;
            case "2":
                player.Defend(enemy);
                break;
            case "3":
                if (player.Run(enemy))
                {
                    // running ends battle immediately
                    return;
                }
                break;
            default:
                Console.WriteLine($"{player.Name} hesitated and got hit!");
                player.TakeDamage(enemy);
                break;
        }

        // Enemy’s turn if still alive
        if (enemy.Hp > 0)
        {
            enemy.Attack(player);
            Console.WriteLine($"{player.Name} HP: {player.Hp} | {enemy.Name} HP: {enemy.Hp}");
        }
        
        Display.DrawSpacer();
    }
}