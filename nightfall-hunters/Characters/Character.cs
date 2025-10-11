namespace nightfall_hunters.classes;

public abstract class Character : Pronouns
{
    private string _name;
    private int _maxHp;
    private int _hp;
    private int _damage;
    private int _gold;

    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrWhiteSpace(value)
            ? "Unknown Character"
            : value;
    }

    public int MaxHp
    {
        get => _maxHp;
        protected set => _maxHp = value > 0 ? value : 1;
    }

    public int Hp
    {
        get => _hp;
        set => _hp = value < 0 ? 0 : (value > MaxHp ? MaxHp : value);
    }

    public int Damage
    {
        get => _damage;
        set => _damage = value < 0 ? 0 : value;
    }

    public int Gold
    {
        get => _gold;
        set => _gold = value < 0 ? 0 : value;
    }

    public virtual string Icon { get; set; } = "⚔️";
    public abstract string Role { get; set; }

    public Character(string name, Gender gender, int maxHp = 100,
        int damage = 20, int gold = 100)
    {
        Name = name;
        Gender = gender;
        MaxHp = maxHp;
        Hp = maxHp;
        Damage = damage;
        Gold = gold;
    }

    public abstract void
        SpecialAttack(Character opponent); // Could also be an interface?

    public int TakeDamage(int damage)
    {
        int damageBonus = Helper.RollDice();

        int damageTaken = damage + damageBonus;
        Hp -= damageTaken;

        return damageTaken;
    }

    public string Info() =>
        $"👤 {Name} | {Icon} {Role} | ❤️ {Hp}/{MaxHp} | 💥 {Damage} | 💰 {Gold}";
}