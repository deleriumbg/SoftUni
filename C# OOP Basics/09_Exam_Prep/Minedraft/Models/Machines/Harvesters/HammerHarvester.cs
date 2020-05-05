public class HammerHarvester : Harvester
{
    private const int IncreaseOreOutput = 3;
    private const int IncreaseEnergyRequirment = 2;

    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput * IncreaseOreOutput, energyRequirement * IncreaseEnergyRequirment)
    {
    }

    public override string ToString()
    {
        return $"Hammer Harvester - {this.Id}\n{base.ToString()}";
    }
}
