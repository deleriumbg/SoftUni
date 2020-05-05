using System;

namespace Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice = decimal.Parse(Console.ReadLine());
            decimal totalExpenses = 0.0m;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    totalExpenses += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    totalExpenses += mousePrice;
                }
                if (i % 6 == 0)
                {
                    totalExpenses += keyboardPrice;
                }
                if (i % 12 == 0)
                {
                    totalExpenses += displayPrice;
                }
            }
            Console.WriteLine($"Rage expenses: {totalExpenses:f2} lv.");
        }
    }
}
