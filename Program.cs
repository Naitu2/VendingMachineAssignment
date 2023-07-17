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
            Cocoa classicCocoa = new Cocoa("Classic Cocoa", 3.0, Ingredient.Sugar);
            Cocoa darkCocoa = new Cocoa("Dark Cocoa", 3.5);

            Coffee classicCoffee = new Coffee("Classic Coffee", 2.5, Ingredient.Sugar);
            Coffee blackCoffee = new Coffee("Black Coffee", 2.0);
            Coffee cappuccino = new Coffee("Cappuccino", 3.0, Ingredient.Milk, Ingredient.Sugar);

            Beverage greenTea = new Tea("Green Tea", 1.8, Ingredient.Honey, Ingredient.Lemon);
            Beverage chaiTea = new Tea("Chai Tea", 2.0, Ingredient.Cinnamon, Ingredient.Cloves);


            VendingMachine vendingMachine = new VendingMachine(10, chaiTea, classicCoffee);

            vendingMachine.AddBeverage(classicCocoa);
            vendingMachine.AddBeverage(blackCoffee);
            vendingMachine.RemoveBeverage(classicCocoa);

            vendingMachine.LoadCups(2);
            vendingMachine.LoadIngredients(50, Ingredient.TeaLeaves);
            vendingMachine.LoadIngredients(30);

            vendingMachine.ConnectedToWater = true;

            Menu.Start(vendingMachine);
        }
    }
}
