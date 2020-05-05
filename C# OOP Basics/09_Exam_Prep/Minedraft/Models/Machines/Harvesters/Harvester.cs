using System;

public abstract class Harvester : Machine
{
    private static double MaxEneryRequirement = 20_000;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get
        {
            return oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return energyRequirement;
        }
        protected set
        {
            if (value < 0 || value >= MaxEneryRequirement)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        return $"Ore Output: {this.OreOutput}\nEnergy Requirement: {this.EnergyRequirement}";
    }
}
