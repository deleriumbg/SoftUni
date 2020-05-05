using System;

public abstract class Provider : IProvider
{
    private const double DefaultDurability = 1000;
    private double durability;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = DefaultDurability;
    }

    public int ID { get; protected set; }

    public double Durability
    {
        get
        {
            return this.durability;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(Constants.BrokenEntity, this.GetType().Name, this.ID));
            }

            this.durability = value;
        }
    }
    public double EnergyOutput { get; protected set; }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityDecrease;
    }
    
    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + $"Durability: {this.Durability}";
    }
}