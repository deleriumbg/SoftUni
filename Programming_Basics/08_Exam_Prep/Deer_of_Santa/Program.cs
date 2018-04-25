using System;

namespace Deer_of_Santa
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysMissing = int.Parse(Console.ReadLine());
            int foodTotal = int.Parse(Console.ReadLine());
            double firstDeer = double.Parse(Console.ReadLine());
            double secondDeer = double.Parse(Console.ReadLine());
            double thirdDeer = double.Parse(Console.ReadLine());

            double foodNeeded = daysMissing * (firstDeer + secondDeer + thirdDeer);
            if (foodTotal >= foodNeeded)
            {
                Console.WriteLine($"{Math.Floor(foodTotal - foodNeeded)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodNeeded - foodTotal)} more kilos of food are needed.");
            }
        }
    }
}
