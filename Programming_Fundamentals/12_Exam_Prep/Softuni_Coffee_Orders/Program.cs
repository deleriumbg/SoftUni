using System;
using System.Globalization;

namespace Softuni_Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal priceTotal = 0.0m;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsulesCount = long.Parse(Console.ReadLine());

                decimal currentPrice = pricePerCapsule * (DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * capsulesCount);
                priceTotal += currentPrice;
                Console.WriteLine($"The price for the coffee is: ${currentPrice:f2}");
            }

            Console.WriteLine($"Total: ${priceTotal:f2}");
        }
    }
}
