using nightfall_hunters.classes;
using nightfall_hunters.game;
using nightfall_hunters.helpers;
using nightfall_hunters.quests;
using nightfall_hunters.ui;

namespace nightfall_hunters;

class Program
{
    public static string Title = "✨🗡️ Nightfall Hunters 🗡️✨";
    static bool _useMockData = true;
    
    static void Main(string[] args)
    {
        var player = _useMockData
            ? new Player("Emma", Gender.Female, PlayerRole.Archer)
            : new Player();
            
        while (true) 
        {
            Console.Clear(); 
            ui.Display.DrawHeader(player);
            
            if (string.IsNullOrEmpty(player.Name)) 
            {
                GameIntro.Run(player); 
                continue; 
            }
            
            if (player.Hp <= 0) 
            {
                GameOverHandler.Handle(ref player); 
                continue; 
            }
            
            GameMenu.Show(player); 
        }
    }
}