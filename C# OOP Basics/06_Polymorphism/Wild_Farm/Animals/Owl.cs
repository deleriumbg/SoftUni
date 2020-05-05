using System;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override Type[] PreferredFood => new Type[] {typeof(Meat)};
    protected override double WeightMultiplier => 0.25;

    public override string MakeSound()
    {
        return "Hoot Hoot";
    }
}
