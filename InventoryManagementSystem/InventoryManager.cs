using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class InventoryManager
    {
        // 1. Private static variable to hold the single instance
        private static InventoryManager _instance = null;
        private static readonly object _lock = new object();

        // 2. Dictionary to store products (Key: ProductId, Value: Product object)
        private Dictionary<string, Product> _products;

        // 3. Private constructor so no external code can instantiate it using 'new'
        private InventoryManager()
        {
            _products = new Dictionary<string, Product>();
        }

        // 4. Public static property to provide global access to the instance
        public static InventoryManager Instance
        {
            get
            {
                // Thread-safe lock to prevent issues if multiple processes access it simultaneously
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new InventoryManager();
                    }
                    return _instance;
                }
            }
        }

        // --- CRUD OPERATIONS ---

        // ADD PRODUCT
        public bool AddProduct(Product product)
        {
            if (_products.ContainsKey(product.ProductId))
            {
                Console.WriteLine($"Error: Product with ID {product.ProductId} already exists.");
                return false;
            }
            _products.Add(product.ProductId, product);
            Console.WriteLine($"Success: {product.ProductName} added to inventory.");
            return true;
        }

        // UPDATE PRODUCT
        public bool UpdateProduct(string productId, string newName, int newQuantity, double newPrice)
        {
            if (!_products.ContainsKey(productId))
            {
                Console.WriteLine($"Error: Product with ID {productId} not found.");
                return false;
            }

            Product product = _products[productId];
            product.ProductName = newName;
            product.Quantity = newQuantity;
            product.Price = newPrice;

            Console.WriteLine($"Success: Product ID {productId} updated.");
            return true;
        }

        // DELETE PRODUCT
        public bool DeleteProduct(string productId)
        {
            if (!_products.ContainsKey(productId))
            {
                Console.WriteLine($"Error: Product with ID {productId} not found.");
                return false;
            }
            _products.Remove(productId);
            Console.WriteLine($"Success: Product ID {productId} removed from inventory.");
            return true;
        }

        // DISPLAY ALL PRODUCTS
        public void DisplayInventory()
        {
            Console.WriteLine("\n--- Inventory Status ---");
            foreach (var item in _products.Values)
            {
                Console.WriteLine($"ID: {item.ProductId} | Name: {item.ProductName} | Stock: {item.Quantity} | Price: Rs.{item.Price}");
            }
            Console.WriteLine("--------------------------------\n");
        }
    }
}