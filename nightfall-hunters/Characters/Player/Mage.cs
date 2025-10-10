namespace nightfall_hunters.classes;

public class Mage : Player
{
    public override string Icon { get; set; } = "🔮";
    public override string Role { get; set; } = "Mage";

    public Mage(string name, Gender gender)
        : base(name, gender)
    {
        MaxHp = 120;
        Hp = 120;
        Damage = 40;
    }

    public override void Attack(Character opponent)
    {
        Console.WriteLine($"{Name} casts a spell towards {opponent.Name}!");
        TakeDamage(opponent);

        Console.WriteLine(
            $"{Name} HP: {Hp} | {opponent.Name} HP: {opponent.Hp}");
    }
}