using System;

namespace Three_Brothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double third = double.Parse(Console.ReadLine());
            double fishingTime = double.Parse(Console.ReadLine());

            double totalTime = 1 / (1 / first + 1 / second + 1 / third) + (1 / (1 / first + 1 / second + 1 / third)) * 0.15;
            Console.WriteLine($"Cleaning time: {totalTime:f2}");
            double timeLeft = fishingTime - totalTime;
            if (timeLeft > 0)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft):f0} hours.");
            }
            else
            {
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(Math.Abs(timeLeft)):f0} hours.");
            }
        }
    }
}
