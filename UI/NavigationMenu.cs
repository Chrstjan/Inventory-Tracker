using Inventory_Tracker.Services;
using Inventory_Tracker.Helper;

namespace Inventory_Tracker.UI
{
    internal class NavigationMenu
    {
         private bool showMenu = true;
         private List<MenuItem> menuItems;

        public NavigationMenu()
        {
            menuItems = new List<MenuItem>
            {
                new MenuItem("Handle inventory", () => { var invMenu = new InventoryMenu(); invMenu.InventoryList(); showMenu = false; }),
                new MenuItem("Show inventory", async () => { await ProductService.GetProducts(); showMenu = false; }),
                new MenuItem("Exit", () => Exit())
            };
        }

        internal async void MainMenu()
        {
            while (showMenu)
            {
                Console.Clear();

                Console.Write("Inventory Tracker 1.0\n" +
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

        private void Exit()
        {
            Console.WriteLine("Exiting...");
            showMenu = false;
        }
    }
}
