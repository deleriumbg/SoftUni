using System.Text;

public class Tesla : IElectricCar
{
    public string Model { get; private set; }
    public string Color { get; private set; }
    public int BatteryCount { get; private set; }

    public Tesla(string model, string color, int batteryCount)
    {
        Model = model;
        Color = color;
        BatteryCount = batteryCount;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{this.Color} Tesla {this.Model} with {this.BatteryCount} Batteries");
        result.AppendLine(this.Start());
        result.AppendLine(this.Stop());
        return result.ToString().Trim();
    }
}
