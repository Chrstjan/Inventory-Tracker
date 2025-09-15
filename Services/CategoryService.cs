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
                return await context.Categories.ToListAsync();
            }
        }
    }
}
