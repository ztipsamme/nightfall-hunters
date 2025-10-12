namespace nightfall_hunters.Quests;

public class MixPoison : Puzzle, IMix
{
    private readonly Dictionary<string, string> _ingredients = new()
    {
        { "Snake Fang Powder", "🐍" },
        { "Crimson Nightshade Petal", "🌿" },
        { "Spider Ichor", "🕷" },
        { "Essence of Shadow", "💧" },
        { "Moonbloom Nectar", "🌼" },
        { "Soul Dust", "⚱️" },
        { "Black Widow Silk", "🕸" },
        { "Obsidian Powder", "🌑" },
        { "Blood Lily Sap", "🩸" }
    };

    private Dictionary<string, string[]> _poisons = new()
    {
        { "Nightshade Venom", ["🌿", "🕷", "💧"] },
        { "Serpent’s Whisper", ["🐍", "🌼", "⚱️"] },
        { "Widow’s Embrace", ["🕸", "🌑", "🩸"] },
    };

    public MixPoison(string title, string description, int reward) :
        base(
            title, description, reward)
    {
    }

    public List<string> Mix()
    {
        List<string> mixture = new();
        var ingredientList = _ingredients.Values.ToList();

        Helper.DrawMenuOptions(ingredientList);
        for (var i = 0; i < 3; i++)
        {
            int selected = Helper.AskFromList(ingredientList);
            string icon = ingredientList[selected];
            string name = _ingredients.Keys.ElementAt(selected);

            mixture.Add(ingredientList[selected]);
            Console.WriteLine(
                $"Added {icon} {name}");
        }

        return mixture;
    }

    public bool CheckSolution()
    {
        int desiredIdx = new Random().Next(0, _poisons.Count);
        string desiredMixture = _poisons.Keys.ElementAt(desiredIdx);

        Ui.DrawDivider();
        Console.WriteLine($"🧪 Create: {desiredMixture}.");
        Ui.DrawDivider();

        List<string> mixture = Mix();

        bool isCorrect = false;

        foreach (string ingredient in mixture)
        {
            if (_poisons.Values.ElementAt(desiredIdx).Contains(ingredient))
                isCorrect = true;
            else
            {
                isCorrect = false;
                break;
            }
        }

        return isCorrect;
    }

    protected override bool Act() => CheckSolution();

    protected override void End(bool act)
    {
        if (act)
        {
            _player.Gold += Reward;
            Console.WriteLine(
                $"💀🧪 {_player.Name} created a perfectly deadly connections!");
            Console.WriteLine($"💰 You gained {Reward} gold!");
            Ui.UpdateHeaderComponent(_player);
        }
        else
        {
            Console.WriteLine(
                $"❌ The mixture fizzles... something went wrong.");
        }

        Ui.Continue("return to the Main Menu");
    }
}