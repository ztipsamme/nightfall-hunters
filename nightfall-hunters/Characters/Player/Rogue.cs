namespace nightfall_hunters.classes;

public class Rogue : Player
{
    public override string Icon { get; set; } = "🗡️";
    public override string Role { get; set; } = "Rogue";
    
    public Rogue(string name, Gender gender)
        : base(name, gender)
    {
        MaxHp = 120;
        Hp = 120;
        Damage = 20;
    }

    public override void Attack(Character opponent)
    {
        Console.WriteLine(
            $"{Name} throws their dagger towards {opponent.Name}!");
        TakeDamage(opponent);

        Console.WriteLine(
            $"{Name} HP: {Hp} | {opponent.Name} HP: {opponent.Hp}");
    }
}