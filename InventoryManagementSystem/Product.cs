using System;

namespace InventoryManagementSystem
{
    public class Product
    {
        // Attributes (Properties in C#)
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        // Constructor to initialize a product
        public Product(string productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }
}