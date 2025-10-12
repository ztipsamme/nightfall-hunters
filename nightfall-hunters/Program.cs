using nightfall_hunters.classes;
using Nightfall_Hunters.Game;
using nightfall_hunters.Quests;

namespace nightfall_hunters;

class Program
{
    static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();

        while (true)
        {
            Console.Clear();
            
            Ui.HeaderComponent(GameManager.Player);

            if (GameManager.Player == null)
            {
                gameManager.CreateCharacter();
                continue;
            }

            gameManager.MainMenu();
        }
    }
}