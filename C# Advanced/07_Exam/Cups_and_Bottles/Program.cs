using System;
using System.Collections.Generic;
using System.Linq;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedLittersOfWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                {
                    cups.Dequeue();
                    wastedLittersOfWater += currentBottle - currentCup;
                }
                else
                {
                    currentCup -= currentBottle;
                    while (currentCup >= 0)
                    {
                        currentCup -= bottles.Pop();
                        if (currentCup <= 0)
                        {
                            wastedLittersOfWater -= currentCup;
                            cups.Dequeue();
                            break;
                        }

                    }
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");

            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
