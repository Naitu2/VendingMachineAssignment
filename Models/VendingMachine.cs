﻿using System;
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
        public bool ConnectedToWater { get; set; } = false;

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

        public void RemoveBeverage(Beverage beverage)
        {
            int index = Array.IndexOf(_beverages, beverage);

            if (index == -1)
            {
                throw new InvalidOperationException("The beverage does not exist in the vending machine!");
            }

            for (int i = index; i < _count - 1; i++)
            {
                _beverages[i] = _beverages[i + 1];
            }

            _beverages[_count - 1] = null;
            _count--;
        }

        public void MakeBeverage(Beverage beverage)
        {
            if (!ConnectedToWater)
            {
                throw new InvalidOperationException("The vending machine is not connected to water!");
            }

            if (!_storage.CheckCupAvailability(1))
            {
                throw new InvalidOperationException("Not enough cups in storage to make a beverage!");
            }

            foreach (var ingredient in beverage.Ingredients)
            {
                if (!_storage.CheckIngredientAvailability(ingredient, 1))
                {
                    throw new InvalidOperationException($"Not enough {ingredient} in storage to make {beverage.Name}!");
                }

                _storage.UseIngredient(ingredient, 1);
            }

            _storage.UseCups(1);
            Console.WriteLine(beverage.Prepare());
        }

        public void LoadCups(int amount)
        {
            try
            {
                _storage.AddCups(amount);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Can't add more cups, storage is full!");
            }
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
    }

}
