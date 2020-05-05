using System;

public abstract class Provider : Machine
{
    private static double MaxEneryOutput = 10_000;

    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return energyOutput;
        }
        protected set
        {
            if (value < 0 || value >= MaxEneryOutput)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"Energy Output: {this.EnergyOutput}";
    }
}
