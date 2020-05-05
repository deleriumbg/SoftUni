using System;

namespace New_Years_Eve_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            int couvert = guestCount * 20;
            if (couvert <= budget)
            {
                int moneyLeft = budget - couvert;
                Console.WriteLine($"Yes! {moneyLeft * 0.4:f0} lv are for fireworks and {moneyLeft * 0.6:f0} lv are for donation.");
            }
            else
            {
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {couvert - budget:f0} lv more.");
            }
        }
    }
}
