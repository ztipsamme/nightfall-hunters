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

    public bool StartBattle()
    {
        string[] options = { "SpecialAttack", "Defend", "TryEscape" };
        Ui.BorderComponent(() => Helper.DrawMenuOptions(options));

        while (_player.Hp > 0 && _enemy.Hp > 0 && !_stopBattle)
        {
            PlayerTurn(options);
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

    private void PlayerTurn(string[] options)
    {
        int selected = _ui.BattleMenuSelect(options);

        switch (selected)
        {
            case 1:
                _player.SpecialAttack(_enemy);
                break;
            case 2:
                _player.Defend(_enemy);
                break;
            case 3:
                if (_player.TryEscapeBattle(_enemy))
                {
                    _enemy.ResetHp();
                    _stopBattle = true;
                    return;
                }

                break;
        }

        _ui.ShowBattleStats(_player, _enemy);
    }

    private void EnemyTurn()
    {
        if (_enemy.Hp > 0)
        {
            Thread.Sleep(800);
            _enemy.SpecialAttack(_player);
            _ui.ShowBattleStats(_player, _enemy);
        }
    }
}