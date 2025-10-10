using Nightfall_Hunters.Battle;
using nightfall_hunters.classes;

namespace nightfall_hunters;

public class Game
{
    private static bool UseMockData = true;
    private static Player _mockPlayer = new Archer("Emma", Gender.Female);

    public Player Player = UseMockData ? _mockPlayer : null;

    public void MainMenu()
    {
        List<(string, Action)> menu = new()
        {
            ("Quest", () => new RandomBattle(Player).Run()),
            ("Rest", Player.Heal),
            ("Exit", () =>
            {
                Console.WriteLine("Until next time brave hunter!");
                Environment.Exit(0);
            })
        };

        Helper.ShowAndUseMenu(menu, "Main Menu");
    }

    private void RandomEnemy()
    {
        Random rnd = new();

        Enemy nextEnemy = Enemy.Enemies[rnd.Next(0, Enemy.Enemies.Count)];
    }

    public void CreateCharacter()
    {
        int startLine = Ui.GetStartLine;
        Console.WriteLine(
            "The city streets are quiet… too quiet. A chill wind snakes through the alleys as you grip your weapon, senses alert. Rumors of mysterious disappearances have reached your ears, and tonight, you hunt.");
        Ui.DrawDivider();

        string name = Helper.AskUntilValid<string>("Enter your name",
            "You entered an invalid name.");
        Ui.DrawDivider();

        Gender gender = Helper.ShowAndUseMenu<Gender>("Enter your gender");
        Ui.DrawDivider();

        string[] roles = { "Warrior", "Mage", "Archer", "Rogue" };

        int role = Helper.ShowAndUseMenu(roles, "Enter your role");

        Player p = role switch
        {
            1 => Player = new Warrior(name, gender),
            2 => Player = new Mage(name, gender),
            3 => Player = new Archer(name, gender),
            4 => Player = new Rogue(name, gender)
        };

        Ui.Continue("create your character");
        Ui.LoadingAnimation("Creating character");
        Ui.Clear(startLine);

        Console.WriteLine(
            $"Welcome, {p.Name} the {roles[role - 1].ToLower()}!.\n" +
            $"The city sleeps peacefully… for now.\n" +
            $"But darkness stirs in the shadows, and only hunters like you can stop it.");

        Ui.Continue();
    }
}