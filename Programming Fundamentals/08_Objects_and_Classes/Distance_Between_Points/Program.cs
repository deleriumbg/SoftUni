using System;
using System.Linq;

namespace Distance_Between_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Point P1 = ReadPoint();
            Point P2 = ReadPoint();
            double distance = CalculateDistance(P1, P2);
            Console.WriteLine($"{distance:f3}");
        }

        public static Point ReadPoint()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point point = new Point();
            point.X = input[0];
            point.Y = input[1];
            return point;
        }

        public static double CalculateDistance (Point P1, Point P2)
        {
            double distance = Math.Sqrt((Math.Abs(P1.X - P2.X) * Math.Abs(P1.X - P2.X) + Math.Abs(P1.Y - P2.Y) * Math.Abs(P1.Y - P2.Y)));
            return distance;
        }
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
