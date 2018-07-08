using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MAX_PIZZA_NAME_LENGTH = 15;
    private const int MAX_NUMBER_OF_TOPPINGS = 10;
    private string name;
    private Dough Dough { get; set; }
    private List<Topping> toppings;

    public string Name
    {
        get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_PIZZA_NAME_LENGTH)
            {
                throw new ArgumentException($"Pizza name should be between 1 and {MAX_PIZZA_NAME_LENGTH} symbols.");
            }
            name = value;
        }
    }

    public List<Topping> Toppings
    {
        get { return toppings; }
        private set
        {
            if (value.Count > MAX_NUMBER_OF_TOPPINGS)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MAX_NUMBER_OF_TOPPINGS}].");
            }
            toppings = value;
        }
    }

    public Pizza(string name)
    {
        Name = name;
        Toppings = new List<Topping>();
    }

    public Pizza(Dough dough, string name, List<Topping> toppings)
    {
        Dough = dough;
        Name = name;
        Toppings = toppings;
    }

    public void AddDough(Dough dough)
    {
        this.Dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException($"Number of toppings should be in range [0..{MAX_NUMBER_OF_TOPPINGS}].");
        }
        this.Toppings.Add(topping);
    }

    public double TotalCalories()
    {
        return this.Dough.CalculateDoughCalories() + this.Toppings.Sum(x => x.CalculateToppingCalories());
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.TotalCalories():f2} Calories.";
    }
}
