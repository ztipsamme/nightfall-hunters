using nightfall_hunters;
using nightfall_hunters.classes;

namespace Nightfall_Hunters.Battle;

public class RandomBattle : Quest
{
    Random _rnd = new();
    private Player _player;
    private Enemy _enemy;
    private bool _escaped = false;

    public RandomBattle(Player player) : base(player)
    {
        _player = player;
        _enemy = Enemy.Enemies[_rnd.Next(0, Enemy.Enemies.Count)];
    }
    
    private void BattleAction()
    {
        var selected = Helper.AskUntilValid("Select action",
            $"Must be between 1 and {Options.Length}.",
            validate: input =>
                int.TryParse(input, out int opt) && opt >= 1 &&
                opt <= Options.Length,
            convert: input => int.Parse(input)
        );
        Ui.DrawDivider();

        Action action = selected switch
        {
            1 => () => _player.Attack(_enemy),
            2 => () => _player.Defend(_enemy),
            3 => () => _escaped = _player.TryEscapeBattle(_enemy),
            _ => () => Console.WriteLine("Invalid choice, you lose your turn!")
        };

        action();

        if (selected == 3) return;

        Ui.DrawDivider();
        if (_enemy.Hp > 0)
        {
            _enemy.Attack(_player);
        }

        Ui.DrawDivider();
        Ui.DrawDivider('-');
    }

    public override void Result()
    {
        if (_enemy.Hp <= 0)
        {
            double gold = _rnd.Next(0, (int)_enemy.Gold);
            _player.Gold += gold;
            Console.WriteLine($"🎉 You defeated {_enemy.Name}!");
            Console.WriteLine($"💰 You gained {gold} gold!");
        }
        else if (_player.Hp <= 0)
        {
            Console.WriteLine($"💀 {_player.Name} died...");
        }

        _enemy.Hp = _enemy.MaxHp;

        Ui.Continue("return to the Main Menu");
    }

    public override void Run()
    {
        if (_player.Hp < 1)
        {
            Console.WriteLine(
                $"❤️‍🩹{_player.Name}'s HP is too low to battle. Fuel up by resting.");
            Ui.Continue("return to the Main Menu");
            return;
        }

        Console.WriteLine($"⚔️ {_player.Name} encounters {_enemy.Name}!");
        Ui.DrawDivider();

        Console.WriteLine(_enemy.Info());
        Ui.DrawDivider('-');
        BattleMenu();

        while (_player.Hp > 0 && _enemy.Hp > 0 && !_escaped)
        {
            BattleAction();

            if (_enemy.Hp <= 0 || _player.Hp <= 0) break;
        }

        Result();
    }
}