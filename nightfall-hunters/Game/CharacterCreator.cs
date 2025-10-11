using nightfall_hunters;
using nightfall_hunters.classes;

namespace Nightfall_Hunters.Game;

public static class CharacterCreator
{
    private static string[] _roles = { };
    private static string _name = null;
    private static Gender? _gender;
    
    public static Player CreateCharacter()
    {
        int startLine = Ui.GetStartLine;
        Intro();

        _name = ChooseName();
        _gender = ChooseGender();

        _roles = ChooseRole(out int role);

        Player player = ConstructPlayer(role);

        Ui.Continue("create your character");
        Ui.LoadingAnimation("Creating character"); // Simulates storing
        Ui.Clear(startLine);

        WelcomeMessage(role);

        Ui.Continue();

        return player;
    }

    private static void WelcomeMessage(int role)
    {
        Console.WriteLine(
            $"Welcome, {_name} the {_roles[role - 1].ToLower()}!.\n" +
            $"The city sleeps peacefully… for now.\n" +
            $"But darkness stirs in the shadows, and only hunters like you can stop it.");
    }

    private static void Intro()
    {
        Console.WriteLine(
            "The city streets are quiet… too quiet. A chill wind snakes through the alleys as you grip your weapon, senses alert. Rumors of mysterious disappearances have reached your ears, and tonight, you hunt.");
        Ui.DrawDivider();
    }

    private static Player ConstructPlayer(int role)
    {
        if (_gender == null)
            throw new InvalidOperationException("Gender has not been set.");
        
        Player p = role switch
        {
            1 => new Archer(_name, _gender.Value),
            2 => new Mage(_name, _gender.Value),
            3 => new Rogue(_name, _gender.Value),
            4 => new Warrior(_name, _gender.Value),
        };
        return p;
    }

    private static string[] ChooseRole(out int role)
    {
        string[] roles = { "Archer", "Mage", "Rogue", "Warrior" };

        role = Helper.ShowAndUseMenu(roles, "Enter your role");
        return roles;
    }

    private static Gender ChooseGender()
    {
        Gender gender = Helper.ShowAndUseMenu<Gender>("Enter your gender");
        Ui.DrawDivider();
        return gender;
    }

    private static string ChooseName()
    {
        string name = Helper.AskUntilValid<string>("Enter your name",
            "You entered an invalid name.");
        Ui.DrawDivider();
        return name;
    }
}