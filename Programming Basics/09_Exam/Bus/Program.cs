using System;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengers = int.Parse(Console.ReadLine());
            int stops = int.Parse(Console.ReadLine());

            for (int i = 1; i <= stops; i++)
            {
                int passengersOut = int.Parse(Console.ReadLine());
                int passengersIn = int.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    passengers = passengers - passengersOut + passengersIn + 2;
                }
                else
                {
                    passengers = passengers - passengersOut - 2 + passengersIn;
                }
            }
            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
