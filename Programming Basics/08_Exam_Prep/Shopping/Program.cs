using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int chocolate = int.Parse(Console.ReadLine());
            double milk = double.Parse(Console.ReadLine());
            int clementines = chocolate - (int)(Math.Ceiling(chocolate * 0.35));
            double totalExpenses = (chocolate * 0.65) + (milk * 2.70) + (clementines * 0.20);
            if (budget >= totalExpenses)
            {
                Console.WriteLine($"You got this, {(budget - totalExpenses):f2} money left!");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {(totalExpenses - budget):f2} more!");
            }
        }
    }
}
