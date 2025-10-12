using nightfall_hunters.classes;

namespace nightfall_hunters.Quests.Battle;

public class BattleUi
{
    public void ShowOrUpdateEnemyStats(Enemy enemy)
    {
        int startLine = Ui.GetStartLine;
        Console.SetCursorPosition(0,8);
        Ui.ClearLine();
        Console.SetCursorPosition(0,8);
        Console.WriteLine(enemy.Info());
        Console.SetCursorPosition(0, startLine + 1);
    }

    public int BattleMenuSelect(string[] options)
    {
        return Helper.AskUntilValid(
            "Select action",
            $"Must be between 1 and {options.Length}.",
            input => int.TryParse(input, out int opt) && opt >= 1 &&
                     opt <= options.Length,
            input => int.Parse(input)
        );
    }
}