using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineAssignment.Models;

namespace VendingMachineAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Beverage tea = new Tea();
            Beverage coffee = new Coffee();
            Beverage cocoa = new Cocoa();

            VendingMachine vendingMachine = new VendingMachine(5, tea, coffee);

            vendingMachine.AddBeverage(cocoa);
            vendingMachine.RemoveBeverage(cocoa);

            vendingMachine.LoadCups(100);
            vendingMachine.LoadIngredients(50, Ingredient.TeaLeaves);
            vendingMachine.LoadIngredients(30);
            vendingMachine.ConnectedToWater = true;

            Menu.Start(vendingMachine);
        }
    }
}
