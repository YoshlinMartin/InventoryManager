using System;
using System.Collections.Generic;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Inventory object
            Inventory inventory = new Inventory();
            bool running = true;

            Console.WriteLine("=== Welcome to Inventory Manager ===");

            // Main program loop
            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. List Items");
                Console.WriteLine("4. Search Item");
                Console.WriteLine("5. View Full Inventory (with indices)");
                Console.WriteLine("6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        inventory.AddItem();
                        break;
                    case "2":
                        inventory.RemoveItem();
                        break;
                    case "3":
                        inventory.ListItems();
                        break;
                    case "4":
                        inventory.SearchItem();
                        break;
                    case "5":
                        inventory.ViewInventory();
                        break;
                    case "6":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }

    // Class to manage the inventory
    class Inventory
    {
        // List to hold all inventory items
        private List<Item> items;

        // Constructor initializes the list
        public Inventory()
        {
            items = new List<Item>();
        }

        // Add a new item to the inventory
        public void AddItem()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter item quantity: ");
            int quantity;
            // Ensure valid integer input
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid number. Try again:");
            }

            Console.Write("Enter item price: ");
            double price;
            // Ensure valid double input
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Try again:");
            }

            // Create a new Item object and add it to the list
            Item newItem = new Item(name, quantity, price);
            items.Add(newItem);
            Console.WriteLine($"Added {name} to inventory!");
        }

        // Remove an item from the inventory
        public void RemoveItem()
        {
            Console.Write("Enter the name of the item to remove: ");
            string name = Console.ReadLine();
            // Search for item by name (case-insensitive)
            Item itemToRemove = items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
                Console.WriteLine($"{name} removed from inventory.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        // List all items in inventory with details
        public void ListItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("\nInventory List:");
            foreach (Item item in items)
            {
                Console.WriteLine(item);
            }
        }

        // View inventory with index numbers for reference
        public void ViewInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("\nFull Inventory with Indices:");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
        }

        // Search for an item by name
        public void SearchItem()
        {
            Console.Write("Enter item name to search: ");
            string name = Console.ReadLine();
            Item foundItem = items.Find(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (foundItem != null)
            {
                Console.WriteLine("Item found:");
                Console.WriteLine(foundItem);
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }

    // Class to represent an item in inventory
    class Item
    {
        // Properties
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        // Constructor
        public Item(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        // Override ToString to display item details with Rand currency
        public override string ToString()
        {
            return $"Name: {Name}, Quantity: {Quantity}, Price: R{Price:F2}";
        }
    }
}