using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Water_Supplies
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalAmountOfWater = double.Parse(Console.ReadLine());
            double[] bottles = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int bottleCapacity = int.Parse(Console.ReadLine());

            List<int> unfilledBottlesIndexes = new List<int>();

            if ((int)totalAmountOfWater % 2 == 0)
            {
                for (int i = 0; i < bottles.Length; i++)
                {
                    if (totalAmountOfWater >= bottleCapacity - bottles[i])
                    {
                        totalAmountOfWater -= bottleCapacity - bottles[i];
                    }
                    else
                    {
                        unfilledBottlesIndexes.Add(i);
                        totalAmountOfWater -= bottleCapacity - bottles[i];
                    }
                }
            }
            else
            {
                for (int i = bottles.Length - 1; i >= 0; i--)
                {
                    if (totalAmountOfWater >= bottleCapacity - bottles[i])
                    {
                        totalAmountOfWater -= bottleCapacity - bottles[i];
                    }
                    else
                    {
                        unfilledBottlesIndexes.Add(i);
                        totalAmountOfWater -= bottleCapacity - bottles[i];
                    }
                }
            }

            if (totalAmountOfWater >= 0)
            {
                Console.WriteLine($"Enough water!\r\nWater left: {totalAmountOfWater}l.");
            }
            else
            {
                Console.WriteLine($"We need more water!\r\nBottles left: {unfilledBottlesIndexes.Count}");
                Console.WriteLine($"With indexes: {string.Join(", ", unfilledBottlesIndexes)}");
                Console.WriteLine($"We need {Math.Abs(totalAmountOfWater)} more liters!");
            }
        }
    }
}
