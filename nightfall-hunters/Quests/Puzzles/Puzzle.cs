namespace nightfall_hunters.Quests;

public abstract class Puzzle : Quest
{
    protected int Reward { get; }
    
    public Puzzle(string title, string description, int reward) : base(title,
        description)
    {
        Reward = reward;
    }

    protected abstract bool Act();

    protected virtual void End(bool act)
    {
        if (act)
        {
            _player.Gold += Reward;
            Console.WriteLine($"🎉 You won!");
            Console.WriteLine($"💰 You gained {Reward} gold!");
        }
        else
        {
            Console.WriteLine($"❌ You lost!");
        }
        
        Ui.Continue("return to the Main Menu");
    }

    public override void Run()
    {
        Ui.Header(Title);
        Console.WriteLine(Description);

        End(Act());
    }
}