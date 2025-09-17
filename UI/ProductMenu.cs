using Inventory_Tracker.Models;
using Inventory_Tracker.Services;

namespace Inventory_Tracker.UI
{
    internal class ProductMenu
    {
        private bool showMenu = true;

        internal void ProductsList(List<Product> products)
        {
            while (showMenu)
            {
                Console.Clear();

                foreach (var item in products)
                {
                    Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Quantity: {item.Quantity}, Category: {item?.Category?.Title}");
                    Console.WriteLine("\nEnter: the id of a product for a detailed view (0-9)");
                    Console.WriteLine("Enter: 'return' to return to previous menu");
                    string input = Console.ReadLine();

                    if (!string.IsNullOrEmpty(input) && input.ToLower() == "return")
                    {
                        var menu = new NavigationMenu();
                        menu.MainMenu();
                        showMenu = false;
                    }
                    else if (int.TryParse(input, out int id) && products.Any(i => i.Id == id))
                    {
                        ProductService.GetProductById(id);
                        showMenu = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
        }

        internal async void SingleProduct(Product product)
        {
            bool inDetailView = true;
            while (inDetailView)
            {
                Console.Clear();
                Console.WriteLine($"{product?.Title}: {product}, Category: {product?.Category}");
                Console.WriteLine("\nEnter: 'return' to leave detailed view");
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && input.ToLower() == "return")
                {
                    await ProductService.GetProducts();
                    Console.ReadKey();
                    inDetailView = false;
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
