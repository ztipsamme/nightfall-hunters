using nightfall_hunters.classes;

namespace nightfall_hunters.Shop;

public class ShopManager
{
    Shop _shop = new();

    private void ShowInventory(Player player)
    {
        while (true)
        {
            int startLine = Ui.GetStartLine;

            Ui.BorderComponent(() => player.ShowInventory());

            string[] menu = player.Inventory.Total == 0
                ? new[] { "Back" }
                : new[] { "Use Item", "Back" };

            int optionIdx = Helper.ShowAndUseMenu(menu);

            if (menu[optionIdx] == "Back")
            {
                Ui.Continue("to go back.");
                return;
            }

            int itemIdx =
                Helper.AskFromList(player.Inventory.Items, "Use item");

            var item = player.Inventory.Items[itemIdx];
            player.UseItem(item.Name);
            Thread.Sleep(1400);
            Ui.Clear(startLine);
        }
    }

    public void Enter(Player player)
    {
        List<Item> items = new()
        {
            new Item("Medicin", 50, 30),
            new Item("Potion", 100, 75),
        };

        foreach (Item item in items)
        {
            _shop.AddItem(item);
        }
        
        Ui.Header("📖 The Bookstore (secret curiosity _shop) 📖",
            ConsoleColor.DarkBlue);

        bool run = true;

        List<(string, Action)> menu = new()
        {
            ("Buy Items", () => _shop.BuyItems(player)),
            ("Sell Items", () => _shop.SellItem(player)),
            ("View Inventory", () => ShowInventory(player)),
            ("Exit Shop", () =>
            {
                Console.WriteLine("🚪 Exiting Shop");
                run = false;
            })
        };

        while (run)
        {
            int startLine = Ui.GetStartLine;
            Helper.ShowAndUseMenu(menu, "Menu");

            Ui.Clear(startLine);
        }
    }
}