using Inventory_Tracker.Data;
using Inventory_Tracker.Models;
using Inventory_Tracker.UI;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Tracker.Services
{
    internal class ProductService
    {
        internal static async Task<List<Product>> GetProducts()
        {
            Console.Clear();

            using (var context = new AppDbContext())
            {
                var products = await context.Products.ToListAsync();

                var productMenu = new ProductMenu();
                productMenu.ProductsList(products);

                return products;
            }
        }

        internal static void GetProductById(int productId)
        {
            using var context = new AppDbContext();

            var product = context.Products.Find(productId);

            if (product == null)
            {
                Console.Clear();
                Console.WriteLine($"Product with ID: {productId} not found");
                return;
            }

            var productMenu = new ProductMenu();
            productMenu.SingleProduct(product);

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
