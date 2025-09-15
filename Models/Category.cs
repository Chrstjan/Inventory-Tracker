namespace Inventory_Tracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Product> Products { get; set; }

        public Category() { }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}";
        }
    }
}
