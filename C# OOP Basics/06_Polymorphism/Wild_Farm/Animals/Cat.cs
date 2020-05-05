using System;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
    }

    protected override Type[] PreferredFood => new Type[] {typeof(Vegetable), typeof(Meat)};
    protected override double WeightMultiplier => 0.30;

    public override string MakeSound()
    {
        return "Meow";
    }
}
