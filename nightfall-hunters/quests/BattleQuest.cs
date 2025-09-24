using nightfall_hunters.classes;
using nightfall_hunters.ui;

namespace Nightfall_Hunters.quests;

public class BattleQuest : Quest
{   
    private Player _player;
    private Enemy _enemy;

    public BattleQuest(string name, Player player,
        Enemy enemy) : base(name)
    {
        _player = player;
        _enemy = enemy;
    }

    public override void Start()
    {
        Description.Show(_player, _enemy);
        Display.DrawSpacer();

        BattleSystem.Start(_player, _enemy);

        if (_enemy.IsDefeated)
        {
            IsCompleted = true;
            Console.WriteLine("Mission success!");
        }
        else Console.WriteLine("Mission failed.");
    }
}
