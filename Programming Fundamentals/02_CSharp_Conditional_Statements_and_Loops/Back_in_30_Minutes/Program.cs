using System;

namespace Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int newMinutes = minutes + 30;

            if (newMinutes < 60)
            {
                Console.WriteLine($"{hours}:{newMinutes:d2}");
            }
            else
            {
                hours++;
                newMinutes -= 60;
                if (hours < 24)
                {
                    Console.WriteLine($"{hours}:{newMinutes:d2}");
                }
                else
                {
                    hours -= 24;
                    Console.WriteLine($"{hours}:{newMinutes:d2}");
                }
            }
        }
    }
}
