using nightfall_hunters.classes;
using Nightfall_Hunters.Game;
using nightfall_hunters.Quests;

namespace nightfall_hunters;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();

        while (true)
        {
            Console.Clear();
            
            Ui.HeaderComponent(Game.Player);

            if (Game.Player == null)
            {
                game.CreateCharacter();
                continue;
            }

            game.MainMenu();
        }
    }
}