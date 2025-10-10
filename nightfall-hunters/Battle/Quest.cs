namespace nightfall_hunters.classes;

public abstract class Quest
{
    private Player _player;
    public virtual string[] Options { get; set; } =
        { "Attack", "Defend", "TryEscapeBattle" };

    public Quest(Player player)
    {
        _player = player;
    }

    public abstract void Run();

    public virtual void BattleMenu()
    {
        for (int i = 0; i < Options.Length; i++)
            Console.WriteLine($"{i + 1}: {Options[i]}");
    }

    public abstract void Result();
}