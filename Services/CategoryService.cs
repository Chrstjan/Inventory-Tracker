using Inventory_Tracker.Data;
using Inventory_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Tracker.Services
{
    internal class CategoryService
    {
        internal static async Task<List<Category>> GetCategories()
        {
            using (var context = new AppDbContext())
            {
                Console.WriteLine("Categories");
                var categories = await context.Categories.ToListAsync();

                foreach (var item in categories)
                {
                    Console.WriteLine($"{item}");
                }

                return categories;
            }
        }

        internal static void CreateCategory(string title)
        {
            using (var context = new AppDbContext())
            {
                context.Categories.Add(new Category { Title = title });
                context.SaveChanges();
            }
        }
    }
}
