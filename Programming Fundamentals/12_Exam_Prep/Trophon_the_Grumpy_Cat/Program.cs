using System;
using System.Collections.Generic;
using System.Linq;

namespace Trophon_the_Grumpy_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> priceRatings = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string typeOfPriceRatings = Console.ReadLine();

            long entryPointPrice = priceRatings[entryPoint];
            List<long> leftResult = new List<long>();
            for (int i = 0; i < entryPoint; i++)
            {
                switch (typeOfItems)
                {
                    case "cheap" when priceRatings[i] < entryPointPrice:
                    case "expensive" when priceRatings[i] >= entryPointPrice:
                        leftResult.Add(priceRatings[i]);
                        break;
                }
            }

            List<long> rightResult = new List<long>();
            for (int i = entryPoint + 1; i < priceRatings.Count; i++)
            {
                switch (typeOfItems)
                {
                    case "cheap" when priceRatings[i] < entryPointPrice:
                    case "expensive" when priceRatings[i] >= entryPointPrice:
                        rightResult.Add(priceRatings[i]);
                        break;
                }
            }

            switch (typeOfPriceRatings)
            {
                case "positive":
                    leftResult = leftResult.Where(x => x > 0).ToList();
                    rightResult = rightResult.Where(x => x > 0).ToList();
                    break;
                case "negative":
                    leftResult = leftResult.Where(x => x < 0).ToList();
                    rightResult = rightResult.Where(x => x < 0).ToList();
                    break;
            }

            Console.WriteLine(leftResult.Sum() >= rightResult.Sum()
                ? $"Left - {leftResult.Sum()}"
                : $"Right - {rightResult.Sum()}");
        }
    }
}
