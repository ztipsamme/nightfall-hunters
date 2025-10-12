using nightfall_hunters.classes;

namespace nightfall_hunters.Shop;

public class Shop
{
    private readonly List<Item> _items  = new();

    public void AddItem(Item item) => _items.Add(item);
    public void ListItems()
    {
        Console.WriteLine("Assortment");
        if (_items.Count == 0)
        {
            Console.WriteLine("(empty)");
            return;
        }

        for (int i = 0; i < _items.Count; i++)
        {
            Item item = _items[i];
            Console.WriteLine($"{i + 1}.  {item.Info()}");
        }
    }

    public void BuyItems(Player player)
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("Nothing to buy!");
            return;
        }

        Ui.BorderComponent(() => ListItems());

        while (true)
        {
            int startLine = Ui.GetStartLine;
            string[] menu = { "Buy Item", "Back" };

            int optionIdx = Helper.ShowAndUseMenu(menu);

            if (optionIdx == 1)
            {
                Ui.Continue("to go back.");
                return;
            }

            int itemIdx = Helper.AskFromList(menu, "Buy item");

            Item item = _items[itemIdx];

            if (player.Gold < item.Price)
            {
                Console.WriteLine("💸 Not enough gold!");
                continue;
            }

            player.Pay(item.Price);
            player.AddItem(item);
            Thread.Sleep(1400);
            Ui.Clear(startLine);
        }
    }

    public void SellItem(Player player)
    {
        while (true)
        {
            int startLine = Ui.GetStartLine;

            Ui.BorderComponent(() => player.ShowInventory());

            string[] menu = player.Inventory.Total == 0
                ? new[] { "Back" }
                : new[] { "Sell Item", "Back" };

            int optionIdx = Helper.ShowAndUseMenu(menu);

            if (menu[optionIdx] == "Back")
            {
                Ui.Continue("to go back.");
                return;
            }

            if (optionIdx == 1)
            {
                Ui.Continue("to go back.");
                return;
            }

            int itemIdx = Helper.AskFromList(_items, "Sell item");

            var item = player.Inventory.Items[itemIdx];
            player.SellItem(item);
            Thread.Sleep(1400);
            Ui.Clear(startLine);
        }
    }
}