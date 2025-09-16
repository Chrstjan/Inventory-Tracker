namespace Inventory_Tracker.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        //Constructor for EF Core
        public Product() { }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Quantity: {Quantity}, Price: {Price}";
        }
    }
}
