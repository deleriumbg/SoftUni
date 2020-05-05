using System;

namespace Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int toyTrucks = int.Parse(Console.ReadLine());
            double sum = puzzles * 2.60 + dolls * 3 + teddyBears * 4.10 + minions * 8.20 + toyTrucks * 2;
            int toysCount  = puzzles + dolls + teddyBears + minions + toyTrucks;
            if (toysCount >= 50)
            {
                sum *= 0.75;
            }
            sum *= 0.9;
            if (sum >= holidayPrice)
            {
                Console.WriteLine($"Yes! {sum - holidayPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {holidayPrice - sum:f2} lv needed.");
            }
        }
    }
}
