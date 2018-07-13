using System;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Height), "Height must be non-zero or positive");
            }
            height = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Width), "Width must be non-zero or positive");
            }
            width = value;
        }
    }

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (this.height + this.width);
    }

    public override double CalculateArea()
    {
        return this.height * this.width;
    }

    public sealed override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
