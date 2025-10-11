using nightfall_hunters;
using Nightfall_Hunters.Characters;
using nightfall_hunters.classes;

public abstract class Player : Character, ILootGold
{
    Random _rnd = new Random();

    protected Player(string name, Gender gender) : base(name, gender)
    {
    }

    public void Defend(Enemy enemy)
    {
        Console.WriteLine($"{Name} defends and takes less damage.");
        Hp -= enemy.Damage / 2;
    }

    public bool TryEscapeBattle(Enemy enemy)
    {
        Console.WriteLine($"👟 {Name} tries to escape...");
        enemy.TakeDamage(Damage);

        if (_rnd.Next(1, 3) % 2 == 0) return true;

        Console.WriteLine(
            $"{enemy.Name} catches {PronounObject}. The battle continues...");
        return false;
    }

    public void Heal()
    {
        int heal = 10;
        Hp += heal;

        if (Hp == MaxHp) Console.WriteLine("❤️ You've reached max HP!");
        else Console.WriteLine($"❤️You've healed +{heal}");
    }
    
    public int LootGold(Character opponent)
    {
        int lootGold = opponent.Gold;
        Gold += lootGold;
        opponent.Gold -= Gold;
        
        return lootGold;
    }
}