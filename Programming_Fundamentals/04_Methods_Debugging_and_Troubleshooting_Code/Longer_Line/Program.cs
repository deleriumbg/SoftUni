using System;

namespace Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double maxDistance = double.MinValue;
            double maxX1 = 0.0;
            double maxY1 = 0.0;
            double maxX2 = 0.0;
            double maxY2 = 0.0;
            for (int i = 1; i <=2; i++)
            {
                double x1 = double.Parse(Console.ReadLine());
                double y1 = double.Parse(Console.ReadLine());
                double x2 = double.Parse(Console.ReadLine());
                double y2 = double.Parse(Console.ReadLine());
                if (CalculateDistance(x1, y1, x2, y2) > maxDistance)
                {
                    maxDistance = CalculateDistance(x1, y1, x2, y2);
                    maxX1 = x1;
                    maxY1 = y1;
                    maxX2 = x2;
                    maxY2 = y2;
                }
            }
            PrintClosestPoint(maxX1, maxY1, maxX2, maxY2);
        }

        static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void PrintClosestPoint(double x1, double y1, double x2, double y2)
        {
            double firstDistance = Math.Sqrt((x1 * x1) + (y1 * y1));
            double secondDistance = Math.Sqrt((x2 * x2) + (y2 * y2));
            if (firstDistance <= secondDistance)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }
    }
}
