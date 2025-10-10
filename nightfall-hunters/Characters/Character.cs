using System;

namespace nightfall_hunters.classes;

public abstract class Character : Pronouns
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Damage { get; set; }
    public double Gold { get; set; }
    public int MaxHp { get; init; }

    public virtual string Icon { get; set; } = "⚔️";
    public abstract string Role {get; set;}

    public Character(string name, Gender gender, int hp = 100, int damage = 20, double gold = 100)
    {
        Name = name;
        Gender = gender;
        Hp = hp;
        MaxHp = hp;
        Damage = damage;
        Gold = gold;
    }

    public abstract void Attack(Character opponent);
    
    public void TakeDamage(Character opponent)
    {
        double roll = Helper.RollDice();

        int damage = (int)(opponent.Damage + roll);
        Hp -= damage;
        Console.WriteLine($"{Name} took -{damage} 🩸");
    }
    
    public string Info() => $"👤 {Name} | {Icon} {Role} | ❤️ {Hp}/{MaxHp} | 💥 {Damage} | 💰 {Gold}";

   
}