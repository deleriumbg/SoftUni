public abstract class Mammal : Animal
{
    public string LivingRegion { get; set; }

    protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
    {
        this.LivingRegion = livingRegion;
    }

    public override string ToString()
    {
        return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}
