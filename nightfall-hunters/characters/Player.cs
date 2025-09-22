using System.ComponentModel;
using nightfall_hunters.helpers;
using nightfall_hunters.ui;

namespace nightfall_hunters.classes;

public enum Role { Warrior, Mage, Archer, Rogue }

public class Player : Character
{
    private static readonly Random _rnd = new Random();
    public Role Role { get; set; }
    public string Icon { get; private set; }
    public int MaxHp { get; set; }
    
    public Player(){}

    public Player(string title, Gender gender, Role role )
    {
        Name = title;
        Gender = gender;
        Role = role;
        SetStatsByClass();
    }
    
    public void CreateCharacter()
    {
        int statsLine = Console.CursorTop;

        Name = InputHelper.AskUntilValid(
            "Enter your name:",
            "Must be between 1 and 20 characters.",
            input => !string.IsNullOrEmpty(input) && input.Length > 0 && input.Length <= 20,
            input => input
        );

        Gender = InputHelper.AskEnum<Gender>("Select gender:");
        Role = InputHelper.AskEnum<Role>("Select class:");

        SetStatsByClass();
    }
    
    private void SetStatsByClass()
    {
        switch (Role)
        {
            case Role.Warrior:
                Hp = 150;
                Damage = 20;
                Icon = "⚔️";
                break;
            case Role.Mage:
                Hp = 80;
                Damage = 30;
                Icon = "🔮";
                break;
            case Role.Archer:
                Hp = 100;
                Damage = 25;
                Icon = "🏹";
                break;
            case Role.Rogue:
                Hp = 90;
                Damage = 22;
                Icon = "🗡️";
                break;
        }

        MaxHp = Hp;
        Gold = 100;
    }
    
    public void Defend(Enemy enemy)
    {
        Console.WriteLine($"{Name} defends and takes less damage.");
        TakeDamage(enemy);
    }

    public bool Run(Enemy enemy)
    {
        StoryNodeHelper.StoryTeller($"👟 {Name} tries to run away...");
        TakeDamage(this);

        if (_rnd.Next(1, 3) % 2 == 0)
        {
            int loss = _rnd.Next(10, 100);
            Gold -= loss;
            StoryNodeHelper.StoryTeller($"\n 💸 {PronounSubject} successfully runs away! {enemy.Name} almost slashed {PronounObject} to pieces. {PronounSubject} lost {loss} gold but {PronounSubject.ToLower()}'s safe... for now.");
            return true;
        }

        StoryNodeHelper.StoryTeller($"{enemy.Name} catches the back of {PronounObject} shirt and drags {PronounObject} back into the alley.");
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