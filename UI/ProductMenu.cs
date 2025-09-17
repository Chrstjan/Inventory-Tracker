using Inventory_Tracker.Helper;
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
                    Console.WriteLine($"{item}");
                    Console.WriteLine("Enter the id of a product for detailed view");

                    if (int.TryParse(Console.ReadLine(), out int input) &&
                       input == item.Id)
                    {
                        ProductService.GetProductById(item.Id);
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
            Console.Clear();
            Console.WriteLine($"Single product: {product}");

            Console.WriteLine("Enter: 'return' to leave detailed view");
            string input = Console.ReadLine();

            if (input.ToLower() == "return" && input != null && input != "")
            {
                await ProductService.GetProducts();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input. Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
