using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        try
        {
            shapes.Add(new Circle(3.5));
            shapes.Add(new Rectangle(3.5, 1.2));
            shapes.Add(new Rectangle(1.5, 1.5));
            shapes.Add(new Rectangle(3.4, 1.5));
            shapes.Add(new Circle(3.6));
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
