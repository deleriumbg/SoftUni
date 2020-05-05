using System;

namespace Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string cubeProperty = Console.ReadLine();
            switch (cubeProperty)
            {
                case "face":
                    PrintLengthOfFaceDiagonals(side);
                    break;
                case "space":
                    PrintSpaceDiagonals(side);
                    break;
                case "volume":
                    PrintVolume(side);
                    break;
                case "area":
                    PrintSurfaceArea(side);
                    break;
            }
        }

        static void PrintLengthOfFaceDiagonals(double side)
        {
            double faceDiagonals = Math.Sqrt(2 * side * side);
            Console.WriteLine($"{faceDiagonals:f2}");
        }

        static void PrintSpaceDiagonals(double side)
        {
            double spaceDiagonals = Math.Sqrt(3 * side * side);
            Console.WriteLine($"{spaceDiagonals:f2}");
        }

        static void PrintVolume(double side)
        {
            double volume = side * side * side;
            Console.WriteLine($"{volume:f2}");
        }

        static void PrintSurfaceArea(double side)
        {
            double surfaceArea = 6 * side * side;
            Console.WriteLine($"{surfaceArea:f2}");
        }
    }
}
