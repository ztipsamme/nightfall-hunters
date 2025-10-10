namespace nightfall_hunters.classes;

public class Warrior : Player
{
    public override string Icon { get; set; } = "⚔️";
    public override string Role { get; set; } = "Warrior";

    // Should work but can't figure it out
    // public Warrior(string name, Gender gender) 
    //     : base(name, gender, maxHp: 120, damage: 40)
    // {
    // }

    public Warrior(string name, Gender gender)
        : base(name, gender)
    {
        MaxHp = 120;
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