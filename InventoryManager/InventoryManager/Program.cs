using System;
using System.Collections.Generic;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            bool running = true;

            //Display the options to the user
            Console.WriteLine("=== Welcome to Inventory Manager ===");

            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. List Items");
                Console.WriteLine("4. Search Item");
                Console.WriteLine("5. Exit");

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

    class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        // Method to add an item to the inventory
        public void AddItem()
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter item quantity: ");
            int quantity;
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid number. Try again:");
            }

            Console.Write("Enter item price: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price. Try again:");
            }

            Item newItem = new Item(name, quantity, price);
            items.Add(newItem);
            Console.WriteLine($"Added {name} to inventory!");
        }
       
        // Method to remove an item from the inventory
        public void RemoveItem()
        {
            Console.Write("Enter the name of the item to remove: ");
            string name = Console.ReadLine();
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

        // Method to search for an item in the inventory
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

    
    class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Item(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Quantity: {Quantity}, Price: {Price:C}";
        }
    }
}