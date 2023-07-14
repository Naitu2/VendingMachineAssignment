using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineAssignment.Models
{
    public class VendingMachine
    {
        private Beverage[] _beverages;
        private int _count;
        private int _capacity;
        private Storage _storage;

        public VendingMachine(int size = 15, params Beverage[] beverages)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("Size must be a positive number!");
            }

            _beverages = new Beverage[size];
            _capacity = size;
            _storage = new Storage();

            foreach (Beverage beverage in beverages)
            {
                AddBeverage(beverage);
            }
        }

        public void AddBeverage(Beverage beverage)
        {
            if (_count < _capacity)
            {
                _beverages[_count++] = beverage;
            }
            else
            {
                throw new InvalidOperationException("The vending machine is full!");
            }
        }

        public void MakeBeverage(Beverage beverage)
        {
            foreach (var ingredient in beverage.Ingredients)
            {
                if (!_storage.CheckIngredientAvailability(ingredient, 1))
                {
                    throw new InvalidOperationException($"Not enough {ingredient} in storage to make {beverage.Name}!");
                }

                _storage.UseIngredient(ingredient, 1);
            }

            Console.WriteLine(beverage.Prepare());
        }


        public void LoadIngredients(int amount = 30, Ingredient? loadedIngredient = null)
        {
            if (loadedIngredient != null)
            {
                try
                {
                    _storage.AddIngredient(loadedIngredient.Value, amount);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine($"Can't add more {loadedIngredient}, storage is full!");
                }

                return;
            }
            else
            {
                for (int i = 0; i < _count; i++)
                {
                    Beverage beverage = _beverages[i];

                    foreach (var ingredient in beverage.Ingredients)
                    {
                        try
                        {
                            _storage.AddIngredient(ingredient, amount);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine($"Can't add more {ingredient}, storage is full!");
                            continue;
                        }
                    }
                }
            }
        }


        public Beverage[] GetBeverages()
        {
            return _beverages.Take(_count).ToArray();
        }

        public int BeveragesCount()
        {
            return _count;
        }

        public Beverage GetBeverageAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Invalid beverage index!");
            }

            return _beverages[index];
        }
    }

}
