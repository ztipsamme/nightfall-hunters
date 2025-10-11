using nightfall_hunters.classes;

namespace nightfall_hunters.Quests.Battle;

public static class BattleOutcomeHandler
{
    public static void HandleWin(Player player, Enemy enemy)
    {
        int gold = player.LootGold(enemy);
        Ui.TextColor(Ui.SuccessColor);
        Console.WriteLine($"🎉 You defeated {enemy.Name}!");
        Console.WriteLine($"💰 You gained {gold} gold!");
        Ui.TextColor();
    }

    public static void HandleLose(Player player, Enemy enemy)
    {
        if (enemy.Hp > 0)
        {
            int gold = enemy.LootGold(player);
            
            Ui.TextColor(Ui.SuccessColor);
            Console.Write(
                $"💨 {player.PronounSubject} successfully escapes! {enemy.Name} almost slashed {player.PronounObject} to pieces. 💸 {player.PronounSubject} lost ");
            Ui.TextColor(Ui.DangerColor);
            Console.Write(gold);
            Ui.TextColor(Ui.SuccessColor);
            Console.WriteLine($" gold but {player.PronounSubject.ToLower()}'s safe... for now.\");");
            Ui.TextColor();
        }
        else
        {
            int gold = enemy.LootGold(player);
            Ui.TextColor(Ui.DangerColor);
            Console.WriteLine($"💀 {player.Name} died.");
            Console.WriteLine($"💸 Lost {gold}");
            Ui.TextColor();
        }
    }
}