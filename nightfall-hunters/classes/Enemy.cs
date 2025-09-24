namespace nightfall_hunters.classes;
public class Enemy: Character
{
    public string Role { get; private set; }
    public bool IsDefeated { get; private set; } = false;

    public static Enemy[] Enemies = new Enemy[]
    {
        new Enemy("Sarah", "Newly turned vampire", Gender.Female, 18, 15, 150),
        new Enemy("Mark", "Newly turned vampire", Gender.Male, 15, 12, 110),
        new Enemy("Unknown Vampire", "Vampire", Gender.Male, 50, 10, 100),
        new Enemy("Fangs", "Vampire", Gender.Male, 50, 10, 100),
        new Enemy("Shadow", "Vampire", Gender.Male, 60, 12, 120),
        new Enemy("Vespera", "Vampire", Gender.Female, 55, 12, 115),
        new Enemy("Asmodeus", "Demon", Gender.Male, 65, 14, 130),
        new Enemy("Mazikeen", "Demon", Gender.Female, 80, 20, 180),
        new Enemy("Angel", "Ancient Vampire", Gender.Male, 75, 11, 95),
        new Enemy("Drucilla", "Ancient Vampire", Gender.Female, 70, 17, 140),
        new Enemy("Sanguis", "Vampire Lord", Gender.Male, 85, 13, 105),
    };


    public Enemy(string name, string role, Gender gender, int hp, int damage, double gold) : base(name, gender, hp, damage, gold)
    {
        Role = role;
    }
    
    public static Enemy GetRandomEnemy()
    {   Random rnd = new Random();
        return Enemies[rnd.Next(0, Enemies.Length)];
    }

    public void Stats()
    {
        Console.WriteLine($"👤: {Name} | HP: {Hp} | Damage: {Damage} | Gold: {Gold}");
    }

    public void Defeated()
    {
        IsDefeated = true;
    }
}