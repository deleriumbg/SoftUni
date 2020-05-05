using System;

namespace SoftUni_Airline
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            decimal totalProfit = 0.0m;

            for (int i = 0; i < N; i++)
            {
                int adultPassengersCount = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                int youthPassengersCount = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                decimal currentIncome = (adultPassengersCount * adultTicketPrice) + (youthPassengersCount * youthTicketPrice);
                decimal currentExpences = flightDuration * fuelConsumptionPerHour * fuelPricePerHour;
                totalProfit += (currentIncome - currentExpences);

                Console.WriteLine(currentIncome >= currentExpences
                    ? $"You are ahead with {currentIncome - currentExpences:f3}$."
                    : $"We've got to sell more tickets! We've lost {currentIncome - currentExpences:f3}$.");
            }

            Console.WriteLine($"Overall profit -> {totalProfit:f3}$.");
            Console.WriteLine($"Average profit -> {totalProfit / N:f3}$.");
        }
    }
}
