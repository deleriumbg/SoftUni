using System;
using System.Linq;

namespace Point_in_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point topLeft = new Point(rectangleCoordinates[0], rectangleCoordinates[1]);
            Point bottomRight = new Point(rectangleCoordinates[2], rectangleCoordinates[3]);
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int numberOfPoints = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPoints; i++)
            {
                int[] pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point point = new Point(pointCoordinates[0], pointCoordinates[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
