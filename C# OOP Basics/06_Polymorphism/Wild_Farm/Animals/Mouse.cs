using System;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override Type[] PreferredFood => new Type[] {typeof(Vegetable), typeof(Fruit)};
    protected override double WeightMultiplier => 0.10;

    public override string MakeSound()
    {
        return "Squeak";
    }
}
