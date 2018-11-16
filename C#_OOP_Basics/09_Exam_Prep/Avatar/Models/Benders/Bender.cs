public abstract class Bender
{
    protected Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name { get; private set; }

    public int Power { get; private set; }

    public abstract double GetBenderPower();
}
