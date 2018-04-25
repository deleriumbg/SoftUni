using System;

namespace Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            int time = seconds + (minutes * 60) + (hours * 3600);

            float mps = (float)distanceMeters / time;
            float kmh = ((float)distanceMeters / 1000) / ((float)time / 3600);
            float mph = ((float)distanceMeters / 1609) / ((float)time / 3600);
            Console.WriteLine($"{mps:0.######}");
            Console.WriteLine($"{kmh:0.######}");
            Console.WriteLine($"{mph:0.######}");
        }
    }
}
