using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Models
{
    internal class Cocoa : Beverage
    {
        public Cocoa(string name, double price, params Ingredient[] additionalIngredients)
     : base(name, price, new Ingredient[] { Ingredient.CocoaPowder, Ingredient.Milk }.Concat(additionalIngredients).ToArray())
        {
        }


        protected override string AddHotWater()
        {
            return "Adding hot water to cocoa powder...";
        }

        protected override string Stirring()
        {
            return "Stirring the cocoa...";
        }
    }
}
