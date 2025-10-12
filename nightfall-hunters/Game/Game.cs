using nightfall_hunters.classes;
using Nightfall_Hunters.Game;
using nightfall_hunters.Quests;
using nightfall_hunters.Shop;

namespace nightfall_hunters;

public class Game
{
    private static bool _useMockData = true;
    private static Player _mockPlayer = new Archer("Emma", Gender.Female);

    public static Player Player = _useMockData ? _mockPlayer : null;

    public void MainMenu()
    {
        QuestManager quests = new();
        ShopManager shop = new();

        List<(string, Action)> menu = new()
        {
            ("📜 Quest", quests.PlayNextMainQuest),
            ("🗡️Random Battle", () => quests.PlayRandomBattle(Player)),
            ("📖 The Bookstore (secret curiosity shop) ", () => shop.Enter(Player)),
            ("🚪 Exit", () =>
            {
                Console.WriteLine("Until next time brave hunter!");
                Environment.Exit(0);
            })
        };

        Helper.ShowAndUseMenu(menu, "Main Menu");
    }

    public void CreateCharacter()
    {
        Player = CharacterCreator.CreateCharacter();
    }

    public static void Heal()
    {
        // Implement selection: Medicin, Rest
        Player.Heal();
    }
}