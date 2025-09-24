using nightfall_hunters.classes;
using nightfall_hunters.helpers;
using nightfall_hunters.ui;

public static class BattleSystem
{
    static Random _rnd = new Random();
    static int BattlesDone = 0;
    
    public static void Start(Player player, Enemy enemy)
    {
        Console.WriteLine($"⚔️ {player.Name} encounters {enemy.Name}!");
        enemy.Stats();
        Display.DrawSpacer();
        
        while (player.Hp > 0 && enemy.Hp > 0)
        {
            string choice = BattleMenu.Show(player);
            Display.DrawSpacer();
            
            BattleActions.Execute(choice, player, enemy);
            
            if (enemy.Hp <= 0 || player.Hp <= 0) break;
        }
        
        BattleResult.Resolve(player, enemy, _rnd);
    }
}