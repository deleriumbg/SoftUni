using System;

namespace Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double startDough = double.Parse(Console.ReadLine());
            int breadWeight = int.Parse(Console.ReadLine());
            double breadPrice = double.Parse(Console.ReadLine());
            int breadsSold = int.Parse(Console.ReadLine());
            int pastrySold = int.Parse(Console.ReadLine());

            double dayIncome = breadsSold * breadPrice;
            double doughForUsedBread = breadsSold * breadWeight;
            double breadDoughLeft = startDough - doughForUsedBread;
            double pastryDoughMade = startDough - breadDoughLeft;
            double pastryPrice = breadPrice * 1.25;
            double pastryWeight = breadWeight * 0.8;
            double pastryDoughUsed = pastrySold * pastryWeight;
            double nightIncome = pastrySold * pastryPrice;
            double totalExpenses = (startDough + pastryDoughMade) * 4;
            double pureIncome = (dayIncome + nightIncome) - (totalExpenses / 1000);
            double totalDoughUsed = doughForUsedBread + pastryDoughUsed;
            Console.WriteLine($"Pure income: {pureIncome:f2} lv.\r\nDough used: {totalDoughUsed:f0} g.");
        }
    }
}
