using System;

namespace _08_Exam_Prep
{
    class Program
    {
        static void Main(string[] args)
        {
            double processorPriceUSD = double.Parse(Console.ReadLine());
            double videoCardPriceUSD = double.Parse(Console.ReadLine());
            double ramPriceUSD = double.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());
            double discountTotal = (processorPriceUSD + videoCardPriceUSD) * discount;
            double priceTotal = (processorPriceUSD + videoCardPriceUSD + (ramPriceUSD * ramCount) - discountTotal) * 1.57;
            Console.WriteLine($"Money needed - {priceTotal:f2} leva.");
        }
    }
}
