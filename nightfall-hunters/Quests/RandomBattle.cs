using nightfall_hunters.classes;
using nightfall_hunters.Quests.Battle;

namespace nightfall_hunters.Quests;

public class RandomBattle : IBattle
{
    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }

    public RandomBattle(Player player, Enemy enemy)
    {
        Player = player;
        Enemy = enemy;
    }
    
    private void Intro()
    {
        Console.WriteLine($"⚔️ Enemy: {Enemy.Info()}");
        Ui.DrawDivider('-');
    }
    public void Run()
    {
        Console.WriteLine("=== Random Battle ===");

        if (!BattleValidator.ReadyToBattle(Player)) return;

        Intro();

        var ui = new BattleUI();
        var battle = new BattleEngine(Player, Enemy, ui);
        bool playerWon = battle.StartBattle();

        if (playerWon)
        {
            BattleOutcomeHandler.HandleWin(Player, Enemy);
            Ui.TextColor();
        }
        else
        {
            BattleOutcomeHandler.HandleLose(Player, Enemy);
        }

        Enemy.ResetHp();
        Ui.Continue("return to the Main Menu");
    }
}