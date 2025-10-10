using nightfall_hunters.classes;
using Nightfall_Hunters.Game;

namespace nightfall_hunters;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        
        while (true) 
        {
            Console.Clear();

            Ui.HeaderComponent(game.Player);

            if (game.Player == null)
            {
                game.CreateCharacter();
                continue;
            }
            
            game.MainMenu();
        }
    }
}