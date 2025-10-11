using nightfall_hunters.classes;

namespace nightfall_hunters.Quests.Battle;

public class BattleUI
{
    public void ShowBattleStats(Player player, Enemy enemy)
    {
        Console.WriteLine($"{player.Icon} {player.Name} HP: {player.Hp} | {enemy.Icon} {enemy.Name} HP: {enemy.Hp}");
    }

    public int BattleMenuSelect(string[] options)
    {
        return Helper.AskUntilValid(
            "Select action",
            $"Must be between 1 and {options.Length}.",
            input => int.TryParse(input, out int opt) && opt >= 1 && opt <= options.Length,
            input => int.Parse(input)
        );
    }
}
