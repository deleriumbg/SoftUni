using System;

namespace Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string beverage = Console.ReadLine();
            double volume = double.Parse(Console.ReadLine());
            double energyPer100g = double.Parse(Console.ReadLine());
            double sugarPer100g = double.Parse(Console.ReadLine());

            Console.WriteLine($"{volume}ml {beverage}:");
            Console.WriteLine($"{(energyPer100g * volume) / 100}kcal, {(sugarPer100g * volume) / 100}g sugars");
        }
    }
}
