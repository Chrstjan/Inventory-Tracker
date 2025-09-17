using Inventory_Tracker.Helper;
using Inventory_Tracker.Services;

namespace Inventory_Tracker.UI
{
    internal class InventoryMenu
    {
        private bool showMenu = true;
        private List<MenuItem> menuItems;

        public InventoryMenu()
        {
            menuItems = new List<MenuItem>
            {
                new MenuItem("View categories", async () => { await CategoryService.GetCategories(); showMenu = false; }),
                new MenuItem("View products", async () => { await ProductService.GetProducts(); showMenu = false; }),
                new MenuItem("Go back", () => {var lastMenu = new NavigationMenu(); lastMenu.MainMenu(); showMenu = false; })
            };
        }

        internal async void InventoryList()
        {
            while (showMenu)
            {
                Console.Clear();

                Console.Write("Inventory List\n" +
                                  "---------------------\n");
                for (int i = 0; i < menuItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {menuItems[i].Text}");
                }
                Console.WriteLine("---------------------");

                if (int.TryParse(Console.ReadLine(), out int input) &&
                    input >= 1 && input <= menuItems.Count)
                {
                    await menuItems[input - 1].Action();
                }
                else
                {
                    Console.WriteLine("Invalid input. Press any key to continue...");
                    Console.ReadKey();
                }
            }
           
        }
    }
}
