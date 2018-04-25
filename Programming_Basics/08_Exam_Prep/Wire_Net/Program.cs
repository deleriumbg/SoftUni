using System;

namespace Wire_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double wirePricePerM = double.Parse(Console.ReadLine());
            double wirePricePerKg = double.Parse(Console.ReadLine());

            int totalWire = 2 * width + 2 * length;
            double wirePrice = totalWire * wirePricePerM;
            double wireWeight = totalWire * height * wirePricePerKg;
            Console.WriteLine($"{totalWire}\r\n{wirePrice:f2}\r\n{wireWeight:f3}");
        }
    }
}
