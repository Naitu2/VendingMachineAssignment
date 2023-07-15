﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Models
{
    internal class Tea : Beverage
    {
        public Tea()
        {
            Ingredients = new[]
            {
                Ingredient.TeaLeaves,
                Ingredient.Sugar,
            };

            Name = "Tea";
            Price = 1.5;
        }

        protected override string AddHotWater()
        {
            return "Adding hot water...";
        }

        protected override string Stirring()
        {
            return "Stirring the tea...";
        }
    }
}
