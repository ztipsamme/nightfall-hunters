namespace nightfall_hunters.Quests.Battle;

public class BattleValidator
{
    public static bool ReadyToBattle(Player player)
    {
        if (player.Hp < 1)
        {
            Console.WriteLine(
                $"❤️‍🩹{player.Name}'s HP is too low to battle. Fuel up by resting.");
            Ui.Continue("return to the Main Menu");
            return false;
        }

        return true;
    }
}