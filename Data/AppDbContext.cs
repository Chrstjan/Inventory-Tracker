using Microsoft.EntityFrameworkCore;
using Inventory_Tracker.Models;

namespace Inventory_Tracker.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Project root folder
            var projectRoot = Directory.GetParent(AppContext.BaseDirectory)!
                .Parent!.Parent!.Parent!.FullName;

            var dbPath = Path.Combine(projectRoot, "Data", "inventory.db");
            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
