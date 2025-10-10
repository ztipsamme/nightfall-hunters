
using nightfall_hunters.classes;

public abstract class Player : Character
{
    Random _rnd = new Random();

    public Player(string name, Gender gender) : base(name, gender)
    {
        Gold = 100;
    }

    public void Defend(Enemy enemy)
    {
        Console.WriteLine($"{Name} defends and takes less damage.");
        Hp -= enemy.Damage / 2;
    }

    public bool TryEscapeBattle(Enemy enemy)
    {
        Console.WriteLine($"👟 {Name} tries to escapes...");
        TakeDamage(enemy);

        if (_rnd.Next(1, 3) % 2 == 0)
        {
            int loss = _rnd.Next(10, 100);
            Gold -= loss;
            Console.WriteLine($"\n 💸 {PronounSubject} successfully escapes away! {enemy.Name} almost slashed {PronounObject} to pieces. {PronounSubject} lost {loss} gold but {PronounSubject.ToLower()}'s safe... for now.");
            return true;
        }

        Console.WriteLine($"{enemy.Name} catches the back of {PronounObject} shirt and drags {PronounObject} back into the alley.");
        return false;
    }

    public void Heal()
    {
        int heal = 10;
        Hp += heal;

        if (Hp > MaxHp)
        {
            Hp = MaxHp;
            Console.WriteLine("❤️ You've reached max HP!");
            return;
        }

        Console.WriteLine($"❤️You've healed +{heal}");
    }
}