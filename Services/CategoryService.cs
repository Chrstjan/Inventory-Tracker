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

        internal static async Task CreateCategory(string title)
        {
            var context = new AppDbContext();

            var alreadyExists = await context.Categories.AnyAsync(c => c.Title.ToLower() == title.ToLower());

            if (alreadyExists)
            {
                Console.WriteLine($"Category with title: {title} already exists");
                return;
            }
            
            context.Categories.Add(new Category { Title = title });
            await context.SaveChangesAsync();
            
        }
    }
}
