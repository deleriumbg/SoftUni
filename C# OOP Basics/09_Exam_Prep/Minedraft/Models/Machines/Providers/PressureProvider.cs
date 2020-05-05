public class PressureProvider : Provider
{
    private const double IncreaseEnergyOutput = 1.5;

    public PressureProvider(string id, double energyOutput) : base(id, energyOutput * IncreaseEnergyOutput)
    {
    }

    public override string ToString()
    {
        return $"Pressure Provider - {this.Id}\n{base.ToString()}";
    }
}
