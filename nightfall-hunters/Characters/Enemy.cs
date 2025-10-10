namespace nightfall_hunters.classes;

public class Enemy: Character
{
    public override string Icon { get; set; } = "🧛";
    public override string Role { get; set; } = "Vampire";
    
    public static List<Enemy> Enemies = new List<Enemy>
    {
        new Enemy("Fangs", Gender.Male, 80, 10, 100),
        new Enemy("Shadow", Gender.Male, 80, 12, 100),
        new Enemy("Bloodling", Gender.Male, 80, 8, 100)
    };
    
    public Enemy(string name, Gender gender, int hp, int damage, double gold) : base(name, gender, hp, damage, gold)
    {
    }

    public override void Attack(Character opponent)
    {
        Console.WriteLine($"{Name} attacks {opponent.Name}!");
        TakeDamage(opponent);
        
        Console.WriteLine(
            $"{opponent.Name} HP: {opponent.Hp} | {Name} HP: {Hp}");
    }
}