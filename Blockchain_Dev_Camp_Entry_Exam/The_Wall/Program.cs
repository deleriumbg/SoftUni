using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Wall
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wallSections = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToList();
            int daysNeeded = 30 - wallSections[0];
            List<int> dailyIceUssage = new List<int>();

            for (int day = 0; day < daysNeeded; day++)
            {
                int iceUsed = 0;
                for (int crew = 0; crew < wallSections.Count; crew++)
                {
                    if (wallSections[crew] < 30)
                    {
                        iceUsed += 195;
                        wallSections[crew]++;
                    }
                    
                }
                dailyIceUssage.Add(iceUsed);
            }

            Console.WriteLine(string.Join(", ", dailyIceUssage));
            int goldCoins = dailyIceUssage.Sum() * 1900;
            Console.WriteLine($"{goldCoins} coins");
        }
    }
}
