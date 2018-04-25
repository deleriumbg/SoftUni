using System;

namespace Grape_and_Rakia
{
    class Program
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double grapesPerSqurM = double.Parse(Console.ReadLine());
            double waste = double.Parse(Console.ReadLine());

            double totalGrapes = area * grapesPerSqurM - waste;
            double forRakia = totalGrapes * 0.45;
            double rakia = (forRakia / 7.5) * 9.8;
            double forSell = totalGrapes * 0.55;
            double grapes = forSell * 1.5;
            Console.WriteLine($"{rakia:f2}\r\n{grapes:f2}");
        }
    }
}
