using Nightfall_Hunters.Characters;

namespace nightfall_hunters.classes;

public class Archer : Player
{
    public override string Icon { get; set; } = "🏹";
    public override string Role { get; set; } = "Archer";
    
    public Archer(string name, Gender gender)
        : base(name, gender)
    {
        MaxHp = 150;
        Hp = 150;
        Damage = 30;
    }

    public override void SpecialAttack(Character opponent)
    {
        AttackHelper.FormatActionMessage(Name, opponent, opponent.TakeDamage(Damage),"shots an arrow towards");
    }
}