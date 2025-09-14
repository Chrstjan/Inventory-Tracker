namespace Inventory_Tracker.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Constructor for EF Core
        public Product() { }

        public Product(int id, string title, int quantity, decimal price)
        {
            Id = id;
            Title = title;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Quantity: {Quantity}, Price: {Price}";
        }
    }
}
