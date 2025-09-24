using System.ComponentModel;
using nightfall_hunters.helpers;
using nightfall_hunters.ui;

namespace nightfall_hunters.classes;

public enum PlayerRole { Warrior, Mage, Archer, Rogue }

public class Player : Character
{
    private static readonly Random _rnd = new Random();
    public PlayerRole Role { get; set; }
    public string Icon { get; private set; }
    
    public Player(){}

    public Player(string title, Gender gender, PlayerRole playerRole )
    {
        Name = title;
        Gender = gender;
        Role = playerRole;
        SetStatsByClass();
    }
    
    public void CreateCharacter()
    {
        Display.DrawCenterText("Create Character");
        Display.DrawSpacer();
        
        Name = InputHelper.AskUntilValid(
            "Enter your name:",
            "Must be between 1 and 20 characters.",
            input => !string.IsNullOrEmpty(input) && input.Length > 0 && input.Length <= 20,
            input => input
        );

        Display.DrawSpacer();
        Gender = InputHelper.ShowMenu<Gender>("Select gender:");
        
        Display.DrawSpacer();
        Role = InputHelper.ShowMenu<PlayerRole>("Select class:");

        SetStatsByClass();
    }
    
    private void SetStatsByClass()
    {
        switch (Role)
        {
            case PlayerRole.Warrior:
                Hp = 150;
                Damage = 20;
                Icon = "⚔️";
                break;
            case PlayerRole.Mage:
                Hp = 80;
                Damage = 30;
                Icon = "🔮";
                break;
            case PlayerRole.Archer:
                Hp = 100;
                Damage = 25;
                Icon = "🏹";
                break;
            case PlayerRole.Rogue:
                Hp = 90;
                Damage = 22;
                Icon = "🗡️";
                break;
        }

        Gold = 100;
        MaxHp = Hp;

    }
    
    public void Defend(Enemy enemy)
    {
        Console.WriteLine($"{Name} defends and takes less damage.");
        TakeDamage(enemy);
    }

    public bool Run(Enemy enemy)
    {
        StoryNode.Tell($"👟 {Name} tries to run away...");
        TakeDamage(this);

        if (_rnd.Next(1, 3) % 2 == 0)
        {
            int loss = _rnd.Next(10, 100);
            Gold -= loss;
            StoryNode.Tell($"\n 💸 {PronounSubject} successfully runs away! {enemy.Name} almost slashed {PronounObject} to pieces. {PronounSubject} lost {loss} gold but {PronounSubject.ToLower()}'s safe... for now.");
            return true;
        }

        StoryNode.Tell($"{enemy.Name} catches the back of {PronounObject} shirt and drags {PronounObject} back into the alley.");
        return false;
    }
    
    public void Heal()
        {
            int heal = 10;
            Hp += heal;

            if (Hp > MaxHp)
            {
                Hp = MaxHp;
                Console.WriteLine($"❤️ {Name} has max {PronounPossessive.ToLower()} HP!");
                return;
            }
            
            Console.WriteLine($"❤️{Name} has healed +{heal}");
        }

    public string Status()
    {
        return $"👤: {Name} | {Icon}: {Role} | 💰: {Gold} | ❤️: {Hp}/{MaxHp} | 💥: {Damage} ";
    }
}