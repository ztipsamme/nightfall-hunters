using nightfall_hunters.classes;

namespace nightfall_hunters.Quests.Battle;

public class BattleEngine
{
    private Player _player;
    private Enemy _enemy;
    private BattleUI _ui;
    private bool _stopBattle;

    public BattleEngine(Player player, Enemy enemy, BattleUI ui)
    {
        _player = player;
        _enemy = enemy;
        _ui = ui;
    }

    private (string Label, Action Action)[] BattleOptions()
    {
        return new (string, Action)[]
        {
            ("Basic Attack", () => _player.BasicAttack(_enemy)),
            ("Special Attack", () => _player.SpecialAttack(_enemy)),
            ("Defend", () => _player.Defend(_enemy)),
            ("Try Escape", () =>
            {
                if (_player.TryEscapeBattle(_enemy))
                {
                    _enemy.ResetHp();
                    _stopBattle = true;
                }
            })
        };
    }

    public bool StartBattle()
    {
        var options = BattleOptions();
        Ui.BorderComponent(() =>
            Helper.DrawMenuOptions(options.Select(o => o.Label).ToArray()));

        while (_player.Hp > 0 && _enemy.Hp > 0 && !_stopBattle)
        {
            PlayerTurn();
            if (_enemy.Hp > 0 && !_stopBattle)
            {
                Ui.DrawDivider();
                EnemyTurn();
            }

            Ui.DrawDivider();
            Ui.DrawDivider('—');
        }

        _stopBattle = false;
        return _player.Hp > 0 && _enemy.Hp <= 0;
    }

    private void PlayerTurn()
    {
        var options = BattleOptions();
        int selected =
            _ui.BattleMenuSelect(options.Select(o => o.Label).ToArray());
        options[selected - 1].Action();
        _ui.ShowBattleStats(_player, _enemy);
    }

    private void EnemyTurn()
    {
        if (_enemy.Hp > 0)
        {
            Thread.Sleep(800);
            if (Helper.RollDice() % 2 == 0) _enemy.BasicAttack(_player);
            else _enemy.SpecialAttack(_player);

            _ui.ShowBattleStats(_player, _enemy);
        }
    }
}