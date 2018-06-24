using System;

namespace Sweet_Dessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal moneyAvailable = decimal.Parse(Console.ReadLine());
            int guestsCount = int.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPricePerKg = decimal.Parse(Console.ReadLine());

            int portions = guestsCount % 6 == 0 ? guestsCount / 6 : (guestsCount / 6) + 1;
            decimal totalBananaPrice = bananaPrice * 2 * portions;
            decimal totalEggPrice = eggPrice * 4 * portions;
            decimal totalBerriesPrice = (berriesPricePerKg / 5) * portions;
            decimal totalMoneyNeeded = totalBananaPrice + totalEggPrice + totalBerriesPrice;
            if (moneyAvailable >= totalMoneyNeeded)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalMoneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalMoneyNeeded - moneyAvailable:f2}lv more.");
            }
        }
    }
}
