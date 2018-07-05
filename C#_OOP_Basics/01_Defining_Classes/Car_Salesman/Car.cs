using System;
public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public double Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine, double weight = 0.0, string color = "n/a")
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }

    public override string ToString()
    {
        string weight = this.Weight == 0.0 ? "n/a" : this.Weight.ToString();
        string displacement = this.Engine.Displacement == 0.0 ? "n/a" : this.Engine.Displacement.ToString();
        return
            $"{this.Model}:\r\n" +
            $"  {this.Engine.Model}:\r\n" +
            $"    Power: {this.Engine.Power}\r\n" +
            $"    Displacement: {displacement}\r\n" +
            $"    Efficiency: {this.Engine.Efficiency}\r\n" +
            $"  Weight: {weight}\r\n" +
            $"  Color: {this.Color}";
    }
}