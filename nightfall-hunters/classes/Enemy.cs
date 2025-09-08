namespace nightfall_hunters.classes;

public class Enemy: Character
{
    
    // --- Constructor --- 
    public Enemy(string name, int hp, int damage, int mana, double gold) : base(name, hp, damage, mana, gold)
    {
        Name = name;
        Hp = hp;
        Damage = damage;
        Mana = mana;
        Gold = gold;
    }

    public void Attack(Player player)
    {
        Console.WriteLine($"{Name} attacks {player.Name}!");
        player.Hp -= Damage;

    }
}