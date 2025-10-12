using nightfall_hunters.classes;
using nightfall_hunters.Quests.Battle;

namespace nightfall_hunters.Quests;

public class MainQuest : Quest, IBattle
{
    private BattleUi _ui;
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
        _ui = new BattleUi();
    }

    private void Intro()
    {
        Console.WriteLine(Title);
        _ui.ShowOrUpdateEnemyStats(Enemy);
        Console.WriteLine(Description);
        Ui.DrawDivider('-');
    }

    public override void Run()
    {
        Ui.Header("📜 Main Quest 📜", Ui.SecondaryColor);


        if (!BattleValidator.ReadyToBattle(Player)) return;

        Intro();

        // Implementing ui as an instance is better for conditional stuff
        var ui = new BattleUi();
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