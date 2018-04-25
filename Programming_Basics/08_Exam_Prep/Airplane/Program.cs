using System;

namespace Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int flightLength = int.Parse(Console.ReadLine());

            int flyingMinutes = flightLength + minutes;
            if (flyingMinutes + minutes < 60)
            {
                Console.WriteLine($"{hours}h {flyingMinutes}m");
            }
            else
            {
                int newHours = hours + (flyingMinutes / 60);
                int newMinutes = flyingMinutes % 60;
                if (newHours >= 24)
                {
                    newHours -= 24;
                }
                Console.WriteLine($"{newHours}h {newMinutes}m");
            }
        }
    }
}
