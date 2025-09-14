namespace Inventory_Tracker.UI
{
    internal class NavigationMenu
    {
         private bool showMenu = true;
        internal void MainMenu()
        {
            while (showMenu)
            {
                

                Console.Write("Inventory Tracker 1.0\n" +
                              "---------------------\n");
                Console.WriteLine("1: Handle inventory");
                Console.WriteLine("2: Show inventory");
                Console.WriteLine("3: Show orders");
                Console.WriteLine("4: Show customers");
                Console.WriteLine("5: Exit");
                Console.WriteLine("---------------------");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {

                    case 2:
                        Console.WriteLine("Show inventory");
                        Console.ReadKey();
                        break;
                    case 5:
                        Exit();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Press any key to continue...");
                        Console.ReadKey();
                        break;
                };
            }
        }

        private void Exit()
        {
            Console.WriteLine("Exiting...");
            showMenu = false;
        }
    }
}
