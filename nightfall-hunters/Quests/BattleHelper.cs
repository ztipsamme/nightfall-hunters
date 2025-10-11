using nightfall_hunters.classes;

namespace nightfall_hunters.Quests;

public static class BattleHelper
{
    public static bool ReadyToBattle()
    {
        if (Game.Player.Hp < 1)
        {
            Console.WriteLine(
                $"❤️‍🩹{Game.Player.Name}'s HP is too low to battle. Fuel up by resting.");
            Ui.Continue("return to the Main Menu");
            return false;
        }

        return true;
    }

    public static void DrawBattleMenu(string[] options) =>
        Ui.BorderComponent(() => Helper.DrawMenuOptions(options));

    public static int BattleMenuSelect(string[] options)
    {
        var selected = Helper.AskUntilValid("Select action",
            $"Must be between 1 and {options.Length}.",
            validate: input =>
                int.TryParse(input, out int opt) && opt >= 1 &&
                opt <= options.Length,
            convert: input => int.Parse(input)
        );
        Ui.DrawDivider();

        return selected;
    }

    public static void EnemiesTurn(Player player, Enemy enemy)
    {
        if (enemy.Hp > 0)
        {
            Thread.Sleep(800);
            enemy.SpecialAttack(player);
            ShowBattleStats(player, enemy);
        }
    }

    public static void ShowBattleStats(Player player, Enemy enemy)
    {
        Console.WriteLine(
            $"{player.Icon} {player.Name} HP: {player.Hp} | {enemy
                .Icon} {enemy
                .Name} HP: {enemy.Hp}");
    }
}