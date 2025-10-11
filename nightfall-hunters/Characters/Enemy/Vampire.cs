using Nightfall_Hunters.Characters;

namespace nightfall_hunters.classes.EnemyClasses;

public class Vampire : Enemy
{
    public override string Icon { get; set; } = "🦇";
    public override string Role { get; set; } = "Vampire";

    public Vampire(string name, Gender gender, int maxHp, int damage,
        int gold = 100) : base(name, gender, maxHp, damage, gold)
    {
    }

    public override void SpecialAttack(Character opponent)
    {
        AttackHelper.FormatActionMessage(Name, opponent, opponent.TakeDamage(Damage),
            "bites");
    }
}