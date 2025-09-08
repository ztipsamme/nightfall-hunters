namespace nightfall_hunters.classes;

public class BattleSystem
{
    Random _rnd = new Random();
    private Player _player;
    private Enemy _enemy;
    
    public BattleSystem(Player player, Enemy enemy)
    { 
        _player = player;
        _enemy = enemy;
    }
    public void StartBattle()
    {
        Console.WriteLine($"⚔️ {_player.Name} encounters {_enemy.Name}!");
        while (_player.Hp > 0 && _enemy.Hp > 0)
        {
            string invalidMessage = "Invalid choice, you lose your turn!";
            
            Console.WriteLine("\nYour turn! Choose action: ");
            Console.WriteLine("1 = Attack, 2 = Defend, 3 = Run");

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine(invalidMessage);
                continue;
            }

            switch (input)
            {
                case 1:
                   _player.Attack(_enemy);
                    break;
                case 2:
                   _player.Defend(_enemy);
                    break;
                case 3:
                    _player.Run(_enemy);
                    break; 
                default:
                    Console.WriteLine(invalidMessage);
                    break;
            }

            if (_enemy.Hp <= 0)
            {
                break;
            }

            _enemy.Attack(_player);

            Console.WriteLine($"{_player.Name} HP: {_player.Hp} | {_enemy
                .Name} HP: {_enemy.Hp}");
        }
        
        if (_player.Hp <= 0)
        {
            int loss = _rnd.Next(10, 100);
            _player.Gold -= loss;
            Console.WriteLine($"💀 You died...\n" +
                              $"💸 You lost {loss} gold");
            return;
        }

        int win = _rnd.Next(10, 100);
        _player.Gold += win;
        Console.WriteLine($"🎉 You defeated {_enemy.Name}!");
        Console.WriteLine($"💰 You gained {win} gold");
    }
}