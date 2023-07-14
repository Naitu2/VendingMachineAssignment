using System;
using System.Collections.Generic;
using VendingMachineAssignment.Models;

class Menu
{
    private static List<Beverage> beverages;
    private static VendingMachine machine;

    public static void Start(VendingMachine vendingMachine)
    {
        machine = vendingMachine;
        beverages = new List<Beverage>(machine.GetBeverages());

        do
        {
            Console.Clear();
            DrawMenu();

            Console.Write("\nEnter the number of your selection: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int selectedItem))
            {
                if (selectedItem > 0 && selectedItem <= beverages.Count)
                {
                    try
                    {
                        machine.MakeBeverage(beverages[selectedItem - 1]);
                        Console.WriteLine("\nThank you for using the machine! Press any key to exit...");
                        return;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"\nError: {e.Message}. Press any key to continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid selection. Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else if (input.ToLower() == "exit")
            {
                return;
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number. Press any key to continue...");
                Console.ReadKey();
            }

        } while (true);
    }

    private static void DrawMenu()
    {
        Console.WriteLine("VENDING MACHINE MENU");
        Console.WriteLine("Type \"exit\" to exit\n");
        Console.WriteLine("Please choose a drink to make:");

        for (int i = 0; i < beverages.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {beverages[i].Name} - ${beverages[i].Price}");
        }
    }
}

