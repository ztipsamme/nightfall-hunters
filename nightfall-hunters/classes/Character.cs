using System;

namespace nightfall_hunters.classes;

public class Character
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Damage { get; set; }
    public int Mana { get; set; }
    public double  Gold { get; set; }

    public Character()
    {
        
    }
    public Character(string name, int hp, int damage, int mana, double gold)
    {
        Name = name;
        Hp = hp;
        Damage = damage;
        Mana = mana;
        Gold = gold;
    }
}