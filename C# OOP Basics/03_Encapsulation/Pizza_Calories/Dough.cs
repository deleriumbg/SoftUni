using System;

public class Dough
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public string FlourType
    {
        get { return flourType; }
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public double Weight
    {
        get { return weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            weight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public double CalculateDoughCalories()
    {
        double multiplier = 0.0;
        switch (this.FlourType.ToLower())
        {
            case "white":
                multiplier = 1.5;
                break;
            case "wholegrain":
                multiplier = 1.0;
                break;
        }

        switch (this.BakingTechnique.ToLower())
        {
            case "crispy":
                multiplier *= 0.9;
                break;
            case "chewy":
                multiplier *= 1.1;
                break;
            case "homemade":
                multiplier *= 1.0;
                break;
        }

        return (2 * this.Weight) * multiplier;
    }
}