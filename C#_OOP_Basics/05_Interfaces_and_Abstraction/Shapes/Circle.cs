using System;
public class Circle : IDrawable
{
    public int Radius { get; private set; }

    public Circle(int radius)
    {
        Radius = radius;
    }

    public void Draw()
    {
        double innerRadius = this.Radius - 0.4;
        double outerRadius = this.Radius + 0.4;

        for (double y = this.Radius; y >= -this.Radius; y--)
        {
            for (double x = -this.Radius; x < outerRadius; x += 0.5)
            {
                double value = x * x + y * y;

                if (value >= innerRadius * innerRadius && value <= outerRadius * outerRadius)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}
