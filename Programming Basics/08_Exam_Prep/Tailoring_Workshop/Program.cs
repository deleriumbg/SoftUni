using System;

namespace Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double coverArea = tables * (length + 0.6) * (width + 0.6);
            double squareArea = tables * (length / 2) * (length / 2);
            double usdPrice = coverArea * 7 + squareArea * 9;
            double bgnPrice = usdPrice * 1.85;
            Console.WriteLine($"{usdPrice:f2} USD\r\n{bgnPrice:f2} BGN");
        }
    }
}
