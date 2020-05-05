public class Car
{
    public string Model { get; set; }
    public double Speed { get; set; }

    public Car(string model, double speed)
    {
        Model = model;
        Speed = speed;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}
