using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineAssignment.Models;

public class Storage
{
    public Dictionary<Ingredient, int> Ingredients { get; set; }
    private const int MAX_INGREDIENT_AMOUNT = 100;

    public Storage()
    {
        Ingredients = new Dictionary<Ingredient, int>();
    }

    public void AddIngredient(Ingredient ingredient, int amount)
    {
        if (Ingredients.ContainsKey(ingredient))
        {
            if (Ingredients[ingredient] + amount > MAX_INGREDIENT_AMOUNT)
            {
                throw new InvalidOperationException($"Can't exceed maximum ingredient amount of {MAX_INGREDIENT_AMOUNT}!");
            }
            Ingredients[ingredient] += amount;
        }
        else
        {
            if (amount > MAX_INGREDIENT_AMOUNT)
            {
                throw new InvalidOperationException($"Can't exceed maximum ingredient amount of {MAX_INGREDIENT_AMOUNT}!");
            }
            Ingredients.Add(ingredient, amount);
        }
    }

    public bool CheckIngredient(Ingredient ingredient, int amountNeeded)
    {
        if (!Ingredients.ContainsKey(ingredient))
        {
            return false;
        }

        return Ingredients[ingredient] >= amountNeeded;
    }

    public void UseIngredient(Ingredient ingredient, int amount)
    {
        if (CheckIngredient(ingredient, amount))
        {
            Ingredients[ingredient] -= amount;
        }
        else
        {
            throw new InvalidOperationException("Not enough ingredient in storage!");
        }
    }

    public bool CheckIngredientAvailability(Ingredient ingredient, int amount)
    {
        return Ingredients.ContainsKey(ingredient) && Ingredients[ingredient] >= amount;
    }

}

