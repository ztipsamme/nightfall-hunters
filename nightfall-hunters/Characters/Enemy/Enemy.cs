using Nightfall_Hunters.Characters;
using nightfall_hunters.classes.EnemyClasses;

namespace nightfall_hunters.classes;

public abstract class Enemy : Character, ILootGold
{
    public Enemy(string name, Gender gender, int maxHp, int damage, int
        gold = 100)
        : base(name, gender, maxHp, damage, gold)
    {
    }

    public override void SpecialAttack(Character opponent)
    {
        Console.WriteLine($"{Name} attacks {opponent.Name}!");
        opponent.TakeDamage(Damage);
    }

    public int LootGold(Character opponent)
    {
        int lootGold = new Random().Next(10, 100);
        opponent.Gold -= Gold;
        return lootGold;
    }

    public void ResetHp()
    {
        Hp = MaxHp;
    }

    public override string Info() =>
        $"{Icon} {Name} | ❤️ {Hp}/{MaxHp} | 💰 {Gold}";
}