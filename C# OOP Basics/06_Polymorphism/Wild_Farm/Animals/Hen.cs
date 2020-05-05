using System;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
    }

    protected override Type[] PreferredFood => new Type[] {typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};
    protected override double WeightMultiplier => 0.35;

    public override string MakeSound()
    {
        return "Cluck";
    }
}
