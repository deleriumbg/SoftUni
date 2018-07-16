using System;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
    }

    protected override Type[] PreferredFood => new Type[] {typeof(Meat)};
    protected override double WeightMultiplier => 0.40;

    public override string MakeSound()
    {
        return "Woof!";
    }
}
