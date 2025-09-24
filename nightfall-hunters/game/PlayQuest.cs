using nightfall_hunters.classes;
using Nightfall_Hunters.quests;

namespace nightfall_hunters.game;

public class PlayQuest
{
    public static void Start(Player player)
    {
        var questManager = new QuestManager();

        questManager.AddQuest(new BattleQuest(
            "Alley Ambush",
            player,
            Enemy.Enemies[2]
        ));

        questManager.Start();
    }
}