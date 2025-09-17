
namespace Inventory_Tracker.Helper
{
    public class MenuItem
    {
        public string Text { get; set; }
        public Func<Task> Action { get; set; }

        //Constructor for async methods
        public MenuItem(string text, Func<Task> asyncAction)
        {
            Text = text;
            Action = asyncAction;
        }
        //Constructor for sync methods
        public MenuItem(string text, Action action)
        {
            Text = text;
            Action = () => { action(); return Task.CompletedTask; };
        }
    }
}
