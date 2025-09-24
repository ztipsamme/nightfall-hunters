using nightfall_hunters.ui;

namespace nightfall_hunters.classes;

public class QuestManager
{
    private List<Quest> _quests = new List<Quest>();
    private int currentQuestIndex = 0;

    public void AddQuest(Quest quest) => _quests.Add(quest);

    public void Start()
    {
        while (currentQuestIndex < _quests.Count)
        {
            Quest quest = _quests[currentQuestIndex];
            
            quest.Start();

            if (quest.IsCompleted) currentQuestIndex++;
            else Console.WriteLine("Try again.");
        }

        Console.WriteLine("All quests have been completed.");
    }
}