using System;

namespace Hearthstone
{
    class Program
    {
        static void Main(string[] args)
        {
            int breakTime = int.Parse(Console.ReadLine());
            double packagePrice = double.Parse(Console.ReadLine());
            double adventurePrice = double.Parse(Console.ReadLine());
            double coffeePrice = double.Parse(Console.ReadLine());
            int freeTime = breakTime - (5 + 2 * 3 + 2 * 2);
            double moneySpend = 3 * packagePrice + 2 * adventurePrice + coffeePrice;
            Console.WriteLine($"{moneySpend:f2}\r\n{freeTime}");
        }
    }
}
