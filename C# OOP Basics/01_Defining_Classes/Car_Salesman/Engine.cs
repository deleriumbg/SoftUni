public class Engine
{
    public string Model { get; set; }
    public double Power { get; set; }
    public double Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, double power, double displacement = 0.0, string efficiency = "n/a")
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }
}
