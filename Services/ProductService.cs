using Inventory_Tracker.Data;
using Inventory_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Tracker.Services
{
    internal class ProductService
    {
        internal static async Task<List<Product>> GetProducts()
        {
            using (var context = new AppDbContext())
            {
                var products = await context.Products.ToListAsync();

                foreach (var item in products)
                {
                    Console.WriteLine($"{item}");
                }

                return products;
            }
        }

        internal static void CreateProduct(string title, int quantity, decimal price, int categoryId)
        {
            using var context = new AppDbContext();

            var category = context.Categories.Find(categoryId);

            if (category == null)
            {
                Console.WriteLine($"Category with id: {categoryId} not found");
                return;
            }

            var product = new Product { Title = title, Price = price, Quantity = quantity, CategoryId = categoryId };
            context.Products.Add(product);

            context.SaveChanges();
        }
    }
}
