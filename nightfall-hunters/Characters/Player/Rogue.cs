using Nightfall_Hunters.Characters;

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

    public override void SpecialAttack(Character opponent)
    {
        AttackHelper.FormatActionMessage(Name, opponent, opponent.TakeDamage(Damage),"throws their dagger towards");
    }
}