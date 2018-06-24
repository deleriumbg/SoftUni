using System;

namespace Charity_Marathon
{
    class Program
    {
        static void Main(string[] args)
        {
            int marathonDays = int.Parse(Console.ReadLine());
            long runnersCount = long.Parse(Console.ReadLine());
            int averageNumberOfLaps = int.Parse(Console.ReadLine());
            long lapLength = long.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal donatedMoneyPerKm = decimal.Parse(Console.ReadLine());

            long maxRunners = Math.Min(trackCapacity * marathonDays, runnersCount);
            long totalMeters = maxRunners * averageNumberOfLaps * lapLength;
            decimal totalKm = (decimal)totalMeters / 1000;
            Console.WriteLine($"Money raised: {totalKm * donatedMoneyPerKm:f2}");
        }
    }
}
