namespace nightfall_hunters.Shop;

public class Inventory
{
    public List<Item> Items = new();
    public int Total => Items.Count;

    public void Add(Item item)
    {
        Items.Add(item);
        Console.WriteLine($"🎒Added {item.Name} to inventory.");
    }

    public Item Find(string itemName) => Items.Find(x => x.Name == itemName);

    public void Remove(Item item) => Items.Remove(item);

    public void ListItems()
    {
        Console.WriteLine("Assortment");
        if (Items.Count == 0)
        {
            Console.WriteLine("(empty)");
            return;
        }

        for (int i = 0; i < Items.Count; i++)
        {
            Item  item = Items[i];
            Console.WriteLine($"{i + 1}. {item.Name} | ❤️ +{item.HealingPower} | Selling Price: {item.SellingPrice}");
        }
    }
}