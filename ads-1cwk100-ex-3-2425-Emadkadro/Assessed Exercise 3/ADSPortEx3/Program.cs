using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Item> items = new List<Item>(); // List to store user-added items

            while (true)
            {
                // Display menu options
                Console.WriteLine("\n------------> OPTIMIZED PAYLOAD PLANNER <-------------\n");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Demo generic sort with integers and strings");
                Console.WriteLine("2. Add item for greedy algorithm");
                Console.WriteLine("3. Get optimized payload using greedy algorithm");
                Console.WriteLine("4. Exit program");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DemoGenericSort(); // Test generic sorting
                        break;
                    case "2":
                        AddItem(items); // Add an item to the list
                        break;
                    case "3":
                        GetOptimisedPayload(items); // Calculate optimised payload
                        break;
                    case "4":
                        return; // Exit program
                    default:
                        Console.WriteLine("\nInvalid option. Please try again!3");
                        break;
                }
            }
        }

        static void DemoGenericSort()
        {
            // Demonstrating with integers
            int[] numbers = { 7, 2, 5, 3, 1, 8 };
            Console.WriteLine("Original integers: " + string.Join(", ", numbers));
            SortUtils.InsertSortGen(numbers); // Sort the integer array
            Console.WriteLine("Sorted integers: " + string.Join(", ", numbers));

            // Demonstrating with strings
            string[] words = { "Mercedes-Benz", "Volvo", "Ford", "Jeep", "Aston Martin" };
            Console.WriteLine("Original strings: " + string.Join(", ", words));
            SortUtils.InsertSortGen(words); // Sort the string array
            Console.WriteLine("Sorted strings: " + string.Join(", ", words));
        }


        /// Adds an item to the list by taking user input.
        static void AddItem(List<Item> items)
        {
            //variable for the data validation
             string name;
             int value;
             double weight;
            //add & validate name
            while (true)
            {
                Console.Write("\nEnter item name: ");
                name = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(name))
                {
                    break;
                }
                Console.WriteLine("Invalid name!");
            }
            //add & validate value
            while (true)
            {
                Console.Write("Enter item value (1-10): ");
                if (int.TryParse(Console.ReadLine(), out value) && value >= 1 && value <= 10)
                {
                    break;
                }
                Console.WriteLine("Invalid value!");
            }
            //add & validate weight
            while (true)
            {
                Console.Write("Enter item weight: ");
                if (double.TryParse(Console.ReadLine(), out weight) && weight > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid weight!");
            }

            items.Add(new Item(name, value, weight)); // Add new item to the list
            Console.WriteLine("\n3866Item added successfully!");
        }


        /// Displays the optimised payload using the greedy algorithm.
        static void GetOptimisedPayload(List<Item> items)
        {
            //Add data validation to the GetOptimisedPayload() function 
            if (items.Count == 0)
            {
                Console.WriteLine("No items added yet!");
                return;
            }
            //Max weight can be added 
            double weightLimit = 100.0;
            List<Item> optimizedItems = GreedyUtils.GetGreedyManifesto(items, weightLimit); //Calculating the optimised list by calling GetGreedyManifesto()

            Console.WriteLine("\nOptimised Payload:");
            foreach (var item in optimizedItems)
            {
                //Display optimised items 
                Console.WriteLine($"Name: {item.Name}, Value: {item.Value}, Weight: {item.Weight}, \nRatio: {item.ValRatio:F2}");
            }
        }
    }
}
