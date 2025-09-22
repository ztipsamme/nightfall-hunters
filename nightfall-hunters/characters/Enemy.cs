namespace nightfall_hunters.classes;

public class Enemy: Character
{
    public static  List<Enemy> Enemies = new List<Enemy>
    {
        new Enemy("Fangs", 50, 10, 100 ),
        new Enemy("Shadow", 60, 12, 100 ),
        new Enemy("Bloodling", 10, 8, 100 )
    };
    public Enemy(string name, int hp, int damage, double gold) : base(name, hp, damage, gold)
    {
        Name = name;
        Hp = hp;
        Damage = damage;
        Gold = gold;
    }
    
    public static Enemy GetRandomEnemy()
    {   Random rnd = new Random();
        return Enemies[rnd.Next(0, Enemies.Count)];
    }

    public void Stats()
    {
        Console.WriteLine($"👤: {Name} | HP: {Hp} | Damage: {Damage} | Gold: {Gold}");
    }
}