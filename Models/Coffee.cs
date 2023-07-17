using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Models
{
    internal class Coffee : Beverage
    {
        public Coffee(string name, double price, params Ingredient[] additionalIngredients)
     : base(name, price, new Ingredient[] { Ingredient.CoffeeBeans }.Concat(additionalIngredients).ToArray())
        {
        }


        protected override string AddHotWater()
        {
            return "Adding hot water...";
        }

        protected override string Stirring()
        {
            return "Stirring the coffee...";
        }
    }

}
