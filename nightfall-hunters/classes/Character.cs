using nightfall_hunters.ui;

namespace nightfall_hunters.classes;

public enum Gender { Male, Female, NonBinary }

public interface ICharacter
{
    string Name { get; }
    Gender Gender { get; }
    int Hp { get; set; }
    int Damage { get; }
    double Gold { get; }
    void TakeDamage(ICharacter opponent);
}

public class Character : ICharacter
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public int Hp { get; set; }
    public int MaxHp { get; set; }

    public int Damage { get; set; }
    public double  Gold { get; set; }

    public Character() { }
    public Character(string name, Gender gender, int hp, int damage, double gold)
    {
        Name = name;
        Gender = gender;
        Hp = hp;
        Damage = damage;
        Gold = gold;
        MaxHp = Hp;
    }
    
    public void Attack(ICharacter opponent)
    {
        Console.Write($"{Name} attacks! 💥 ");
        opponent.TakeDamage(opponent);
        Display.DrawSpacer();
    }

    
    public void TakeDamage(ICharacter opponent)
    {
        double roll = Dice.Roll();

        int damage = (int)(opponent.Damage + roll);
        Hp -= damage;
        Console.WriteLine($"{Name} took -{damage} 🩸");
    }
    
    public string PronounSubject => Gender switch
    {
        Gender.Male => "He",
        Gender.Female => "She",
        _ => "They"
    };

    public string PronounObject => Gender switch
    {
        Gender.Male => "him",
        Gender.Female => "her",
        _ => "them"
    };

    public string PronounPossessive => Gender switch
    {
        Gender.Male => "his",
        Gender.Female => "her",
        _ => "their"
    };
}