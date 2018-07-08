using System;

public class Box
{
    public double Length { get; }
    public double Width { get; }
    public double Height { get; }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
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
