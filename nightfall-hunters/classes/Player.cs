using System;
using nightfall_hunters.enums;

namespace nightfall_hunters.classes;

public class Player : Character
{
    Random _rnd = new Random();
    public PlayerClass Class { get; set; }
    public int MaxHp { get; init; }

    
    // --- Constructor --- 
    public Player()
    {
        Console.WriteLine("The city streets are quiet… too quiet. A chill wind snakes through the alleys as you grip your weapon, senses alert. Rumors of mysterious disappearances have reached your ears, and tonight, you hunt.");
        Console.Write("Enter your name: ");
        Name = Console.ReadLine();
        
        PlayerClass playerClass;
        string inputClass;
        
       do
       {
           Console.Write("Choose your class (Warrior, Mage, Archer or Rogue): ");
           inputClass = Console.ReadLine();
           
       } while (!Enum.TryParse(inputClass, true, out playerClass));

        Class = playerClass;
        
        switch (Class)
        {
            case PlayerClass.archer:
                Hp = 150;
                Damage = 30;
                Mana = 100;
                break;        
            case PlayerClass.mage:
                Hp = 120;
                Damage = 40;
                Mana = 110;
                break;        
            case PlayerClass.warrior:
                Hp = 120;
                Damage = 40;
                Mana = 120;
                break;
            case PlayerClass.rogue:
                Hp = 120;
                Damage = 20;
                Mana = 120;
                break;
        }

        Gold = 100;
        MaxHp = Hp;

        Console.WriteLine($"Welcome, {Name} the {Class}!.\n" +
                          $"The city sleeps peacefully… for now.\n" +
                          $"But darkness stirs in the shadows, and only hunters like you can stop it.");
    }
    
    // --- Methods ---

    public void Attack(Enemy enemy)
    {
        Console.WriteLine($"{Name} attacks {enemy.Name}!");
        enemy.Hp -= Damage;
    }

    public void Defend(Enemy enemy)
    {
        Console.WriteLine($"{Name} defends and takes less damage.");
        Hp -= enemy.Damage / 2;
    }

    public void Run(Enemy enemy)
    {
        Console.WriteLine($"{Name} tries to run away...");

        if (_rnd.Next(1, 3) % 2 == 0)
        {
            Console.WriteLine($"{Name} successfully runs away!");
            return;
        }

        Console.WriteLine($"{Name} fails to run away and takes damage!");
        Hp -= enemy.Damage;
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

    public void Status()
    {
        Console.WriteLine($"{Name}'s stats:\n" +
                          $"Gold: {Gold}\n" +
                          $"Class: {Class}\n" +
                          $"HP: {Hp}\n" +
                          $"Damage: {Damage} \n" +
                          $"Mana: {Mana}");
    }
}