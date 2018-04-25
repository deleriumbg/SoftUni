using System;

namespace Friendly_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = double.Parse(Console.ReadLine());
            int fuelUsagePer100km = int.Parse(Console.ReadLine());
            double priceFuelPerLiter = double.Parse(Console.ReadLine());
            double totalMoney = double.Parse(Console.ReadLine());

            double fuelUsed = (distance * fuelUsagePer100km) / 100;
            double fuelPrice = fuelUsed * priceFuelPerLiter;

            if (totalMoney >= fuelPrice)
            {
                Console.WriteLine($"You can take a trip. {totalMoney - fuelPrice:f2} money left.");
            }
            else
            {
                Console.WriteLine($"Sorry, you cannot take a trip. Each will receive {totalMoney / 5:f2} money.");
            }
        }
    }
}
