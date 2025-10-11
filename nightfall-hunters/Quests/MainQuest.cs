using nightfall_hunters.classes;
using nightfall_hunters.Quests.Battle;

namespace nightfall_hunters.Quests;

public class MainQuest : Quest, IBattle
{
    public Player Player
    {
        get => _player;
    }
    public Enemy Enemy { get; set; }
    public bool Completed { get; private set; } = false;

    public MainQuest(Enemy enemy, string title, string description
    ) : base(title, description)
    {
        Enemy = enemy;
    }

    private void Intro()
    {
        Console.WriteLine(Title);
        Console.WriteLine(Description);
        Console.WriteLine($"⚔️ Enemy: {Enemy.Info()}");
        Ui.DrawDivider('-');
    }

    public override void Run()
    {
        Console.WriteLine("=== Main Quest ===");

        if (!BattleValidator.ReadyToBattle(Player)) return;

        Intro();

        var ui = new BattleUI();
        var battle = new BattleEngine(Player, Enemy, ui);
        bool playerWon = battle.StartBattle();

        if (playerWon)
        {
            BattleOutcomeHandler.HandleWin(Player, Enemy);
            Completed = true;
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