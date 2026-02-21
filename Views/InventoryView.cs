using System;
using InventoryManagement.Services;

namespace InventoryManagement.Views
{
    public class InventoryView
    {
        private InventoryService service = new InventoryService();

        [cite_start]public void Run() // The main program loop [cite: 29]
        {
            bool isRunning = true;
            while (isRunning)
            {
                [cite_start]// Display Menu Options [cite: 31, 32, 33, 35, 36]
                Console.WriteLine("\n1. View Inventory\n2. Update Stock\n3. Reset Inventory\n4. Exit");
                string choice = Console.ReadLine();

                if (choice == "1") DisplayInventory();
                else if (choice == "2") UpdateInventory();
                else if (choice == "3") { service.ResetInventory(); Console.WriteLine("Reset complete."); }
                else if (choice == "4") isRunning = false;
            }
        }

        private void DisplayInventory()
        {
            string[,] products = service.GetProducts(); // Get data from service [cite: 28]
            for (int i = 0; i < products.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {products[0, i]} - Stock: {products[1, i]}");
            }
        }

        private void UpdateInventory()
        {
            Console.Write("Select product (1-3): ");
            int index = int.Parse(Console.ReadLine()) - 1;
            Console.Write("New quantity: ");
            string qty = Console.ReadLine();
            service.UpdateStock(index, qty); // Send update to service [cite: 33, 34]
        }
    }
}
