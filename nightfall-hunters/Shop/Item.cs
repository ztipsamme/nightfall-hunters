using nightfall_hunters.classes;

namespace nightfall_hunters.Shop;

public class Item
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Price { get; private set; }
    public int SellingPrice { get; private set; }
    public int HealingPower { get; private set; }

    public Item(string name, int price, int healingPower)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        SellingPrice = price / 2;
        HealingPower = healingPower;
    }

    public void Use(Player player) => player.Heal(HealingPower);

    public string Info() => $"{Name} | ❤️ +{HealingPower} | 💰 {Price}";
}