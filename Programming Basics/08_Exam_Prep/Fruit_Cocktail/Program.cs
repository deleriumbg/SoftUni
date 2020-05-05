using System;

namespace Fruit_Cocktail
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int ordersCount = int.Parse(Console.ReadLine());
            double sum = 0;

            switch (fruit)
            {
                case "Watermelon":
                    if (size == "small")
                    {
                        sum += ordersCount * 56 * 2;
                    }
                    else if (size == "big")
                    {
                        sum += ordersCount * 28.70 * 5;
                    }
                    break;
                case "Mango":
                    if (size == "small")
                    {
                        sum += ordersCount * 36.66 * 2;
                    }
                    else if (size == "big")
                    {
                        sum += ordersCount * 19.60 * 5;
                    }
                    break;
                case "Pineapple":
                    if (size == "small")
                    {
                        sum += ordersCount * 42.10 * 2;
                    }
                    else if (size == "big")
                    {
                        sum += ordersCount * 24.80 * 5;
                    }
                    break;
                case "Raspberry":
                    if (size == "small")
                    {
                        sum += ordersCount * 20 * 2;
                    }
                    else if (size == "big")
                    {
                        sum += ordersCount * 15.20 * 5;
                    }
                    break;
            }
            if (sum > 1000)
            {
                sum *= 0.5;
            }
            else if (sum >= 400 && sum <= 1000)
            {
                sum *= 0.85;
            }
            Console.WriteLine($"{sum:f2} lv.");
        }
    }
}
