using System;

namespace Travel
{
    class Program
    {
        static void Main(string[] args)
        {
            double distance = double.Parse(Console.ReadLine());
            double truckSpeed = double.Parse(Console.ReadLine());
            double speedDifference = double.Parse(Console.ReadLine());
            speedDifference *= 3.6;
            double carSpeed = truckSpeed + speedDifference;
            int truckTime = (int)Math.Ceiling(distance / truckSpeed);
            int carTime = (int)Math.Ceiling(distance / carSpeed);
            Console.WriteLine($"The truck arrived after {truckTime} hours\r\nThe car arrived after {carTime} hours");
        }
    }
}
