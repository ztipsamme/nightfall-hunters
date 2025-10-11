using Nightfall_Hunters.Characters;

namespace nightfall_hunters.classes;

public class Warrior : Player
{
    public override string Icon { get; set; } = "⚔️";
    public override string Role { get; set; } = "Warrior";

    // Should work but can't figure it out
    // public Warrior(string name, Gender gender) 
    //     : base(name, gender, maxHp: 120, damage: 40)
    // {
    // }x

    public Warrior(string name, Gender gender)
        : base(name, gender)
    {
        MaxHp = 120;
        Hp = 120;
        Damage = 40;
    }

    public override void SpecialAttack(Character opponent)
    {
        AttackHelper.FormatActionMessage(Name, opponent, opponent.TakeDamage(Damage),"swings their blade towards");
    }
}