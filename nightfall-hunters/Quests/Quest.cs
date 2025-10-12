using nightfall_hunters.classes;

namespace nightfall_hunters.Quests;

public abstract class Quest
{
    public int TotalQuests = 0;
    protected Player _player = GameManager.Player;

    public string Title;
    public string Description;

    public Quest( string title, string description)
    {
        Title = title;
        Description = description;
        
        TotalQuests++;
    }
    public abstract void Run();
}