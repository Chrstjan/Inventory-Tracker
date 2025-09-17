using Inventory_Tracker.Services;

namespace Inventory_Tracker.UI
{
    internal class InventoryMenu
    {
        private bool showMenu = true;

        internal async void InventoryList()
        {
            Console.Clear();

            Console.Write("Inventory List\n" +
                              "---------------------\n");
            Console.WriteLine("1: View categories");
            Console.WriteLine("2: Edit categories");
            Console.WriteLine("3: View products");
            Console.WriteLine("4: Edit products");
            Console.WriteLine("5: Go back");
            Console.WriteLine("---------------------");

            int input = Convert.ToInt32(Console.ReadLine());
            var menu = new NavigationMenu();

            switch (input)
            {
                case 1:
                    await CategoryService.GetCategories();
                    showMenu = false;
                    break;
                case 3:
                    await ProductService.GetProducts();
                    showMenu = false;
                    break;
                case 5:
                    menu.MainMenu();
                    showMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
