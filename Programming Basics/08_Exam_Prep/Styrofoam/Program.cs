using System;

namespace Styrofoam
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double houseArea = double.Parse(Console.ReadLine());
            int windowsCount = int.Parse(Console.ReadLine());
            double styrofoamPerPackage = double.Parse(Console.ReadLine());
            double packagePrice = double.Parse(Console.ReadLine());

            double house = houseArea - (windowsCount * 2.4);
            house *= 1.1;
            double packagesNeeded = Math.Ceiling(house / styrofoamPerPackage);
            double styrofoamPrice = packagesNeeded * packagePrice;
            if (styrofoamPrice <= budget)
            {
                Console.WriteLine($"Spent: {styrofoamPrice:f2}\r\nLeft: {budget - styrofoamPrice:f2}");
            }
            else
            {
                Console.WriteLine($"Need more: {styrofoamPrice - budget:f2}");
            }
        }
    }
}
