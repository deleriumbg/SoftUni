using System;
using System.Linq;

public abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
        FoodEaten = 0;
    }

    protected virtual Type[] PreferredFood => new[] {typeof(Food)};
    protected virtual double WeightMultiplier => 1.00;

    public void TryToEatFood(Food food)
    {
        Type foodType = food.GetType();
        if (!this.PreferredFood.Contains(foodType))
        {
            throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodType.Name}!");
        }
        this.FoodEaten += food.Quantity;
        this.Weight += food.Quantity * this.WeightMultiplier;
    }

    public abstract string MakeSound();

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.Name}, ";
    }
}
