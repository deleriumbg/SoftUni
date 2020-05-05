using System;

public class Circle : Shape
{
    private double radius;

    public double Radius
    {
        get { return radius; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Radius), "Circle can not have zero or negative radius");
            }
            radius = value;
        }
    }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * this.radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * this.radius * this.radius;
    }

    public sealed override string Draw()
    {
        return base.Draw() + "Circle";
    }
}
