using nightfall_hunters.classes;
using Nightfall_Hunters.Game;
using nightfall_hunters.Quests;
using nightfall_hunters.Shop;

namespace nightfall_hunters;

public class GameManager
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
            ("📖 The Bookstore (secret curiosity shop)", () => shop.Enter(Player)),
            ("🪶 Help out at the Bookstore", () => quests.PlayPuzzleQuest()),
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
}