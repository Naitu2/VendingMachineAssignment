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
        public Cocoa()
        {
            Ingredients = new[]
            {
                Ingredient.CocoaPowder,
                Ingredient.Sugar,
                Ingredient.Milk
            };

            Name = "Cocoa";
            Price = 3.0;
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
