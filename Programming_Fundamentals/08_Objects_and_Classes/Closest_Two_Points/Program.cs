using System;
using System.Linq;

namespace Distance_Between_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Point[] points = ReadPoints();
            Point[] closestPoints = FindClosestTwoPoints(points);
            PrintDistance(closestPoints);
            PrintPoint(closestPoints[0]);
            PrintPoint(closestPoints[1]);
        }

        public static Point ReadPoint()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point point = new Point();
            point.X = input[0];
            point.Y = input[1];
            return point;
        }

        public static Point[] ReadPoints()
        {
            int n = int.Parse(Console.ReadLine());
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                points[i] = ReadPoint();
            }
            return points;
        }

        public static double CalculateDistance(Point P1, Point P2)
        {
            double distance = Math.Sqrt((Math.Abs(P1.X - P2.X) * Math.Abs(P1.X - P2.X) + Math.Abs(P1.Y - P2.Y) * Math.Abs(P1.Y - P2.Y)));
            return distance;
        }

        public static void PrintPoint(Point point)
        {
            Console.WriteLine($"({point.X}, {point.Y})");
        }

        public static void PrintDistance(Point[] points)
        {
            double distance = CalculateDistance(points[0], points[1]);
            Console.WriteLine($"{distance:f3}");
        }

        public static Point[] FindClosestTwoPoints(Point[] points)
        {
            double minDistance = double.MaxValue;
            Point[] closestTwoPoints = null;
            for (int P1 = 0; P1 < points.Length; P1++)
                for (int P2 = P1 + 1; P2 < points.Length; P2++)
                {
                    double distance = CalculateDistance(points[P1], points[P2]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestTwoPoints = new Point[] { points[P1], points[P2] };
                    }
                }
            return closestTwoPoints;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
