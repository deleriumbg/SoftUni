using System;

namespace Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = double.Parse(Console.ReadLine());
            double sum = 0;

            switch (season)
            {
                case "Spring":
                case "Autumn":
                    if (kmPerMonth <= 5000)
                    {
                        sum += kmPerMonth * 4 * 0.75;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        sum += kmPerMonth * 4 * 0.95;
                    }
                    else if (kmPerMonth > 10000 && kmPerMonth <= 20000)
                    {
                        sum += kmPerMonth * 4 * 1.45;
                    }
                    break;
                case "Summer":
                    if (kmPerMonth <= 5000)
                    {
                        sum += kmPerMonth * 4 * 0.90;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        sum += kmPerMonth * 4 * 1.10;
                    }
                    else if (kmPerMonth > 10000 && kmPerMonth <= 20000)
                    {
                        sum += kmPerMonth * 4 * 1.45;
                    }
                    break;
                case "Winter":
                    if (kmPerMonth <= 5000)
                    {
                        sum += kmPerMonth * 4 * 1.05;
                    }
                    else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
                    {
                        sum += kmPerMonth * 4 * 1.25;
                    }
                    else if (kmPerMonth > 10000 && kmPerMonth <= 20000)
                    {
                        sum += kmPerMonth * 4 * 1.45;
                    }
                    break;
            }
            sum *= 0.9;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
