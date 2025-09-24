namespace nightfall_hunters.classes;

public class BattleResult
{
    public static void Resolve(Player player, Enemy enemy, Random rnd)
    {
        if (enemy.Hp <= 0)
        {
            int gold = rnd.Next(10, 100);
            player.Gold += gold;
            Console.WriteLine($"🎉 You defeated {enemy.Name}!");
            Console.WriteLine($"💰 You gained {gold} gold!");
        }
        else if (player.Hp <= 0)
        {
            Console.WriteLine($"💀 {player.Name} died...");
        }
        
        enemy.Hp = enemy.MaxHp;

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}