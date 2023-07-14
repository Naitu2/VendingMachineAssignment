using VendingMachineAssignment.Models;

namespace VendingMachineAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine(5, new Tea());
            vendingMachine.AddBeverage(new Coffee());
            vendingMachine.AddBeverage(new Cocoa());

            vendingMachine.LoadIngredients(50, Ingredient.TeaLeaves);
            vendingMachine.LoadIngredients(50);
            

            Menu.Start(vendingMachine);
        }
    }
}