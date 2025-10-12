using Nightfall_Hunters.Characters;
using nightfall_hunters.Shop;

namespace nightfall_hunters.classes;

public abstract class Player : Character, ILootGold
{
    Random _rnd = new Random();
    public Inventory Inventory { get; private set; }

    protected Player(string name, Gender gender) : base(name, gender)
    {
        Inventory = new Inventory();
    }

    public void Defend(Enemy enemy)
    {
        Console.WriteLine($"{Name} defends and takes less damage.");
        Hp -= enemy.Damage / 2;
    }

    public bool TryEscapeBattle(Enemy enemy)
    {
        Console.WriteLine($"👟 {Name} tries to escape...");
        enemy.TakeDamage(Damage);

        if (_rnd.Next(1, 3) % 2 == 0) return true;

        Console.WriteLine(
            $"{enemy.Name} catches {PronounObject}. The battle continues...");
        return false;
    }

    public void Heal(int amount = 10)
    {
        Hp += amount;

        if (Hp == MaxHp) Console.WriteLine("❤️ You've reached max HP!");
        else Console.WriteLine($"❤️You've healed +{amount}");
    }
    
    public int LootGold(Character opponent)
    {
        int lootGold = opponent.Gold;
        Gold += lootGold;
        opponent.Gold -= Gold;
        
        return lootGold;
    }
    
    public void Pay(int amount)
    {
        Gold -= amount;
    }
    
    public void AddItem(Item item) => Inventory.Add(item);
    
    public void ShowInventory() => Inventory.ListItems();
    
    public void SellItem(Item item)
    {
        Gold += item.SellingPrice;
        Inventory.Remove(item);
        Console.WriteLine($"💰Sold {item.Name} for {item.SellingPrice}");
    }
    
    public void UseItem(string itemName)
    {
        var item = Inventory.Find(itemName);
        if (item == null)
        {
            Console.WriteLine($"❓ You don’t have '{itemName}'.");
            return;
        }

        item.Use(this);
        Inventory.Remove(item);
    }
}