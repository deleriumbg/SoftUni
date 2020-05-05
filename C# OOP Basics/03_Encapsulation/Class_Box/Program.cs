using System;

namespace Class_Box
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);
            box.PrintSurfaceArea(length, width, height);
            box.PrintLateralSurfaceArea(length, width, height);
            box.PrintVolume(length, width, height);
        }
    }
}
