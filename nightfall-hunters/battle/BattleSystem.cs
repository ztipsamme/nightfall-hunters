using nightfall_hunters.classes;
using nightfall_hunters.helpers;
using nightfall_hunters.ui;

public static class BattleSystem
{
    static Random _rnd = new Random();
    
    private static void EndBattle(Player player, Enemy enemy)
    {
        if (enemy.Hp <= 0)
        {
            int win = _rnd.Next(10, 100);
            player.Gold += win;
            Console.WriteLine($"🎉 You defeated {enemy.Name}!");
            Console.WriteLine($"💰 You gained {win} gold"); 
        }
        
        if (player.Hp >= 0) Console.WriteLine("Press any key to return to the main menu...");
        else
        {
            Console.WriteLine($"💀 {player.Name} died...");
            Console.WriteLine("Press any key to continue...");
        }
        

        Console.ReadKey();
    }
    
    public static void Run(Player player, Enemy enemy)
    {
        StartBattle(player, enemy);
        
        string[] menu = ["Attack!", $"Defend {player.PronounPossessive}self.", "Try running to safety."];
        
        while (player.Hp > 0 && enemy.Hp > 0)
        {
            string? selected = InputHelper.ShowMenu("Choose your next move: ", menu);
        
            Display.DrawSpacer();
            
            switch (selected)
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
                        EndBattle(player, enemy);
                        return;
                    };
                    break; 
                default:
                    Console.WriteLine($"{player.Name} failed {player.PronounSubject.ToLower()} next move.");
                    player.TakeDamage(enemy);
                    break;
            }
            
            if (enemy.Hp <= 0) break;
            
            enemy.Attack(player);

            Console.WriteLine($"{player.Name} HP: {player.Hp} | {enemy
                .Name} HP: {enemy.Hp}");
        }
        
        EndBattle(player, enemy);
    }
    
    private static void StartBattle(Player player, Enemy enemy)
    {
        Console.WriteLine($"⚔️ {player.Name} encounters {enemy.Name}!");
        
        enemy.Stats();
    }

}