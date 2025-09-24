using nightfall_hunters.helpers;

namespace nightfall_hunters.classes;

public class BattleMenu
{
    public static string Show(Player player)
    {
        string[] options =
        {
            "Attack!",
            $"Defend {player.PronounPossessive}self.",
            "Try running to safety."
        };

        string choice =
            InputHelper.ShowMenu("Choose your next move: ", options);

        int index = Array.IndexOf(options, choice) + 1;

        return index.ToString();
    }
}