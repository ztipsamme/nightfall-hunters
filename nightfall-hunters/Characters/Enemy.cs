namespace nightfall_hunters.classes;

public class Enemy: Character
{
    public override string Icon { get; set; } = "🧛";
    public override string Role { get; set; } = "Vampire";
    
    public static List<Enemy> Enemies = new List<Enemy>
    {
        new Enemy("Fangs", Gender.Male, 80, 10),
        new Enemy("Shadow", Gender.Male, 80, 12),
        new Enemy("Bloodling", Gender.Male, 80, 8)
    };
    
    public Enemy(string name, Gender gender, int maxHp, int damage, double 
            gold = 100) 
        : base(name, gender, maxHp, damage, gold)
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