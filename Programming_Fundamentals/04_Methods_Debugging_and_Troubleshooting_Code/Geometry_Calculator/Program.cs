using System;

namespace Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            switch (figure)
            {
                case "triangle":
                    double side1 = double.Parse(Console.ReadLine());
                    double side2 = double.Parse(Console.ReadLine());
                    PrintTriangleArea(side1, side2);
                    break;
                case "square":
                    double sideA = double.Parse(Console.ReadLine());
                    PrintSquareArea(sideA);
                    break;
                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    PrintRectangleArea(width, height);
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    PrintCircleArea(radius);
                    break;
                default:
                    break;
            }
        }

        static void PrintTriangleArea(double side1, double side2)
        {
            double area = (side1 * side2) / 2;
            Console.WriteLine($"{area:f2}");
        }

        static void PrintSquareArea(double sideA)
        {
            double area = sideA * sideA;
            Console.WriteLine($"{area:f2}");
        }

        static void PrintRectangleArea(double width, double height)
        {
            double area = width * height;
            Console.WriteLine($"{area:f2}");
        }

        static void PrintCircleArea(double radius)
        {
            double area = Math.PI * radius * radius;
            Console.WriteLine($"{area:f2}");
        }
    }
}
