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
        public Coffee()
        {
            Ingredients = new[]
            {
            Ingredient.CoffeeBeans,
            Ingredient.Sugar,
        };

            Name = "Coffee";
            Price = 2.5;
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
