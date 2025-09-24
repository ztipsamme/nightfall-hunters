using nightfall_hunters.classes;

namespace Nightfall_Hunters.quests;


public class PuzzleQuest : Quest
{
    private Player _player;
    
    private Func<bool> _puzzleCheck;
    
    public PuzzleQuest(string name, Player player, Func<bool> puzzelCheck) : base(name)
    {
        _player = player;
        _puzzleCheck = puzzelCheck;
    }

    public override void Start()
    {
        Description.Show(_player);

        if (_puzzleCheck())
        {
            IsCompleted = true;
            Console.WriteLine("Puzzle completed.");
        }
        else Console.WriteLine("Puzzle failed.");
    }
}