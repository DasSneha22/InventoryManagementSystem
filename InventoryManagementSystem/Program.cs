using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Accessing the Inventory Manager via the Singleton Instance
            InventoryManager inventory = InventoryManager.Instance;

            // 1. Adding Products
            inventory.AddProduct(new Product("P001", "Laptop", 10, 899.99));
            inventory.AddProduct(new Product("P002", "Smartphone", 25, 499.99));
            inventory.AddProduct(new Product("P003", "Wireless Mouse", 50, 24.99));

            // Display current items
            inventory.DisplayInventory();

            // 2. Updating a Product
            inventory.UpdateProduct("P002", "Smartphone (Pro Model)", 20, 549.99);

            // 3. Deleting a Product
            inventory.DeleteProduct("P003");

            // Display final items
            inventory.DisplayInventory();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}