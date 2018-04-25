using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double squareSide = double.Parse(Console.ReadLine());
                double area = squareSide * squareSide;
                Console.WriteLine(Math.Round(area, 3));
            }
            else if (figure == "rectangle")
            {
                double recSideA = double.Parse(Console.ReadLine());
                double recSideB = double.Parse(Console.ReadLine());
                double area = recSideA * recSideB;
                Console.WriteLine(Math.Round(area, 3));
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double area = Math.PI * radius * radius;
                Console.WriteLine(Math.Round(area, 3));
            }
            else if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double area = (side * height) / 2;
                Console.WriteLine(Math.Round(area, 3));
            }
        }
    }
}
