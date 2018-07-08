using System;

public class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private string type;
    private double weight;

    public string Type
    {
        get { return type; }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            weight = value;
        }
    }

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;
    }

    public double CalculateToppingCalories()
    {
        double multiplier = 0.0;
        switch (this.Type.ToLower())
        {
            case "meat":
                multiplier = 1.2;
                break;
            case "veggies":
                multiplier = 0.8;
                break;
            case "cheese":
                multiplier = 1.1;
                break;
            case "sauce":
                multiplier = 0.9;
                break;
        }

        return (2 * this.Weight) * multiplier;
    }
}
