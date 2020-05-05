using System;

public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return length; }
        private set
        {
            ValidateFieldValue(value, "Length");
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            ValidateFieldValue(value, "Width");
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            ValidateFieldValue(value, "Height");
            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public void ValidateFieldValue(double fieldValue, string fieldName)
    {
        if (fieldValue <= 0)
        {
            throw new ArgumentException($"{fieldName} cannot be zero or negative.");
        }
    }

    public void PrintSurfaceArea(double length, double width, double height)
    {
        Console.WriteLine($"Surface Area - {(2 * length * width) + (2 * length * height) + (2 * width * height):f2}");
    }

    public void PrintLateralSurfaceArea(double length, double width, double height)
    {
        Console.WriteLine($"Lateral Surface Area - {(2 * length * height) + (2 * width * height):f2}");
    }

    public void PrintVolume(double length, double width, double height)
    {
        Console.WriteLine($"Volume - {length * width * height:f2}");
    }
}
