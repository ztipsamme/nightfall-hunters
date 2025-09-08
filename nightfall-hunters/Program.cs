using nightfall_hunters.classes;

namespace nightfall_hunters;

class Program
{
    static void RandomEnemy(Player player)
    {   Random rnd = new Random();

        List<Enemy> enemies = new List<Enemy>
        {
            new Enemy("Fangs", 50, 10, 0, 100 ),
            new Enemy("Shadow", 60, 12, 0, 100 ),
            new Enemy("Bloodling", 10, 8, 0, 100 )
        };
        
        Enemy nextEnemy = enemies[rnd.Next(0, enemies.Count)];
        new BattleSystem(player, nextEnemy).StartBattle();
    }

    static void Main(string[] args)
    {
       Player  player = new Player();

     
       
       char response = 'n';
       
       do
       {
           Console.WriteLine("Menu: 1 = Play a quest, 2 = Rest, 3 = Status, 4 = Quit");
           
           if (!int.TryParse(Console.ReadLine(), out int input))
           {
               Console.WriteLine("Invalid input, try again!");
               continue;
           }
           
           switch (input)
           {
               case 1:
                   Console.WriteLine("Starting a quest...");
                   RandomEnemy(player);
                   break;
               case 2:
                   Console.WriteLine("You take a rest...");
                   player.Heal();
                   break;
               case 3:
                   Console.WriteLine("Showing stats...");
                   player.Status();
                   break;
               case 4:
                   Console.Write("Would you like to quit the game? (y/n): ");
                   response = Console.ReadKey().KeyChar;
                   Console.WriteLine(); // Prevents next CW from being on the same row
                   break;
               default:
                   Console.WriteLine("Invalid choice, try again!");
                   break;
           }
           
       } while (player.Hp > 0 && response != 'y');

       if (player.Hp <= 0)
       {
           Console.WriteLine($"💀 You are dead.");
           return;
       }
       Console.WriteLine("Until next time brave hunter!");
       Environment.Exit(0);
    }
}