namespace nightfall_hunters.classes;

public class Warrior : Player
{
    public override string Icon { get; set; } = "⚔️";
    public override string Role { get; set; } = "Warrior";

    public Warrior(string name, Gender gender) : base(name, gender)
    {
        Hp = 120;
        Damage = 40;
    }

    public override void Attack(Character opponent)
    {
        Console.WriteLine(
            $"{Name} swings their blade towards {opponent.Name}!");
        TakeDamage(opponent);

        Console.WriteLine(
            $"{Name} HP: {Hp} | {opponent.Name} HP: {opponent.Hp}");
    }
}