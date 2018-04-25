using System;

namespace Moon
{
    class Program
    {
        static void Main(string[] args)
        {
            int speed = int.Parse(Console.ReadLine());
            int fuel = int.Parse(Console.ReadLine());
            double totalDistance = 384400 * 2;
            double time = Math.Ceiling(totalDistance / speed);
            time += 3;
            double fuelNeeded = fuel * (totalDistance / 100);
            Console.WriteLine(time);
            Console.WriteLine(fuelNeeded);
        }
    }
}
