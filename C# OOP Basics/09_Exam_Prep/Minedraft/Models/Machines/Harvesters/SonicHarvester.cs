public class SonicHarvester : Harvester
{
    public int SonicFactor { get; private set; }

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public override string ToString()
    {
        return $"Sonic Harvester - {this.Id}\n{base.ToString()}";
    }
}
