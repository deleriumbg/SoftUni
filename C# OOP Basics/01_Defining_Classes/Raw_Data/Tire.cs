public class Tire
{
    public int Age { get; set; }
    public double Pressure { get; set; }

    public Tire(double pressure, int age)
    {
        Pressure = pressure;
        Age = age;
    }
}
