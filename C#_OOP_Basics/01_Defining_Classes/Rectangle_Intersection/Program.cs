using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] rectanglesInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int numberOfRectangles = rectanglesInfo[0];
        int intersectionChecks = rectanglesInfo[1];
        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < numberOfRectangles; i++)
        {
            string[] currentRectangle = Console.ReadLine().Split();
            string id = currentRectangle[0];
            double width = double.Parse(currentRectangle[1]);
            double height = double.Parse(currentRectangle[2]);
            double x = double.Parse(currentRectangle[3]);
            double y = double.Parse(currentRectangle[4]);

            Rectangle rectangle = new Rectangle(id, width, height, x, y);
            rectangles.Add(rectangle);
        }

        for (int i = 0; i < intersectionChecks; i++)
        {
            string[] pairs = Console.ReadLine().Split();
            string firstId = pairs[0];
            string secondId = pairs[1];

            Rectangle firstRectangle = rectangles.First(x => x.Id == firstId);
            Rectangle secondRectangle = rectangles.First(x => x.Id == secondId);
            Console.WriteLine(firstRectangle.Intersect(secondRectangle).ToString().ToLower()); 
        }
    }
}
