using Inventory_Tracker.Data;
using Inventory_Tracker.UI;

namespace Inventory_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                Console.WriteLine("DB created or already exists!");
            }

            var menu = new NavigationMenu();
            menu.MainMenu();
        }
    }
}