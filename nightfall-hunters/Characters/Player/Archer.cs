namespace nightfall_hunters.classes;

public class Archer : Player
{
    public override string Icon { get; set; } = "🏹";
    public override string Role { get; set; } = "Archer";

    public Archer(string name, Gender gender) : base(name, gender)
    {
        Hp = 150;
        Damage = 30;
    }

    public override void Attack(Character opponent)
    {
        Console.WriteLine($"{Name} shoots an arrow towards {opponent.Name}!");
        TakeDamage(opponent);

        Console.WriteLine(
            $"{Name} HP: {Hp} | {opponent.Name} HP: {opponent.Hp}");
    }
}