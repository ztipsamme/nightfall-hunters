using Nightfall_Hunters.Characters;
using nightfall_hunters.classes;

namespace nightfall_hunters.Quests;

public class QuestManager
{
   public static MainQuest[] MainQuests =
    {
        new MainQuest(EnemyFactory.GetByName("Fangs"), "Alley Ambush",
            "Suddenly, shadows twist and leap from the walls—thieves or worse."),
        new MainQuest(EnemyFactory.GetByName("Crash"), "Forest Hunt",
            "The forest is alive with whispers and rustling leaves."),
        new MainQuest(EnemyFactory.GetByName("Mazikeen"), "Battle in the Ruins",
            "Crumbled walls and shattered pillars create a battlefield of shadows."),
    };

    public static Puzzle[] PuzzleQuest =
    {
        new MixPoison("🧪 The Art of Quiet Death 🧪",
            "Mix the forbidden ingredients to craft a poison of legend. One mistake, and the venom will claim you instead.",
            25)
    };

    public void PlayNextMainQuest()
    {
        MainQuest? nextQuest =
            MainQuests.FirstOrDefault(quest => quest.Completed == false);

        if (nextQuest == null)
        {
            Console.WriteLine("🎉 All main quests are completed!");
            Ui.Continue("return to the Main Menu");
            return;
        }

        nextQuest.Run();
    }

    public void PlayRandomBattle(Player player) =>
        new RandomBattle(player, EnemyFactory.GetRandom()).Run();

    public void PlayPuzzleQuest() => PuzzleQuest[new Random().Next(0, PuzzleQuest.Length)].Run();
    
}