using System;
using System.Linq;

namespace Circles_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point firstPoint = new Point(firstCoordinates[0], firstCoordinates[1]);
            Point secondPoint = new Point(secondCoordinates[0], secondCoordinates[1]);
            Circle firstCircle = new Circle(firstPoint, firstCoordinates[2]);
            Circle secondCircle = new Circle(secondPoint, secondCoordinates[2]);
            Console.WriteLine(Circle.Intersects(firstCircle, secondCircle) ? "Yes" : "No");
        } 
    }

    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point (int x, int y)
        {
            X = x;
            Y = y;
        }

        public static int CalculateDistance(Point p1, Point p2)
        {
            int distance = (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            return distance;
        }
    }

    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public static bool Intersects (Circle c1, Circle c2)
        {
            double distance = Point.CalculateDistance(c1.Center, c2.Center);
            if (distance <= c1.Radius + c2.Radius)
            {
                return true;
            }
            return false;
        }
    }
}
