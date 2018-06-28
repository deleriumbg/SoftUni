using System;
using System.Globalization;

namespace Sino_The_Walker
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan time = TimeSpan.ParseExact(Console.ReadLine(), "c", CultureInfo.InvariantCulture);
            int numberOfSteps = int.Parse(Console.ReadLine()) % 86400;
            int timePerStep = int.Parse(Console.ReadLine()) % 86400;
            int totalTime = numberOfSteps * timePerStep;
            time = time.Add(TimeSpan.FromSeconds(totalTime));
            Console.WriteLine($"Time Arrival: {time:hh\\:mm\\:ss}");
        }
    }
}
