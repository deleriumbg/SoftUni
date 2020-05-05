public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
    {
    }

    public override string ToString()
    {
        return $"Solar Provider - {this.Id}\n{base.ToString()}";
    }
}
