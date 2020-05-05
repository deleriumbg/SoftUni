using System;

namespace Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double currentKm = double.Parse(Console.ReadLine());
            double totalKm = currentKm;
            for (int i = 0; i < days; i++)
            {
                int percentageIncrease = int.Parse(Console.ReadLine());
                currentKm += currentKm * percentageIncrease / 100;
                totalKm += currentKm;
            }
            if (totalKm >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalKm - 1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - totalKm)} more kilometers");
            }
        }
    }
}
