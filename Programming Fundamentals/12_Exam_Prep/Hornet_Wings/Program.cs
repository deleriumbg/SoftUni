using System;

namespace Hornet_Wings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            decimal metersPer1000Flaps = decimal.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            decimal distance = ((decimal) wingFlaps / 1000) * metersPer1000Flaps; // check if wingFlaps = 0
            decimal flappingSeconds = ((decimal) wingFlaps / 100);
            decimal restingSeconds = (wingFlaps / endurance) * 5;
            decimal totalSeconds = flappingSeconds + restingSeconds;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{totalSeconds:f0} s.");
        }
    }
}
