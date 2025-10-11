using Nightfall_Hunters.Characters;

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

    public override void SpecialAttack(Character opponent)
    {
        AttackHelper.FormatActionMessage(Name, opponent, opponent.TakeDamage(Damage),"casts a spell towards");
    }
}