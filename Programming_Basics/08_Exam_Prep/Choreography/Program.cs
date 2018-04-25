using System;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double stepsPerDay = steps / days;
            double stepsPercentage = Math.Ceiling((stepsPerDay / steps) * 100);
            double percentPerDancer = stepsPercentage / dancers;
            if (stepsPercentage <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentPerDancer:f2}%.");
            }
            else
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {percentPerDancer:f2}% steps to be learned per day.");
            }
        }
    }
}
