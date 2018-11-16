public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity { get; private set; }

    public override double GetBenderPower()
    {
        return base.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        return $"Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:F2}";
    }
}
