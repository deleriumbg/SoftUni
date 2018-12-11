public class PressureProvider : Provider
{
    private const int EnergyMultiplier = 2;
    private const int DurabilityDecrease = 300;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput *= EnergyMultiplier;
        this.Durability -= DurabilityDecrease;
    }
}
