using System;

namespace Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine($"{height * width:f2}");
        }
    }
}
