using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Models
{
    public abstract class Beverage
    {
        public Ingredient[] Ingredients;
        public string Name { get; set; }
        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                if (value >= 0)
                {
                    _price = value;
                }
                else
                {
                    throw new InvalidOperationException("The price can't be less than 0!");
                }
            }
        }

        public string Prepare()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(AddIngredients() + "\n");
            sb.AppendLine(AddHotWater() + "\n");
            sb.AppendLine(Stirring() + "\n");

            return sb.ToString();
            
        }

        protected virtual string AddIngredients()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Adding ");

            for (int i = 0; i < Ingredients.Length; i++)
            {
                string ingredientName = Ingredients[i].ToString();
                string separatedName = Regex.Replace(ingredientName, "(\\B[A-Z])", " $1").ToLower();
                sb.Append(separatedName);

                if (i == Ingredients.Length - 2)
                {
                    sb.Append(" and ");
                }
                else if (i != Ingredients.Length - 1)
                {
                    sb.Append(", ");
                }
            }

            sb.Append("...");

            return sb.ToString();
        }
        protected abstract string AddHotWater();
        protected abstract string Stirring();
    }
}
