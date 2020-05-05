using System;
using System.Collections.Generic;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int count = 1;
            int bestCount = 0;
            int bestNum = 0;

            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    count++;
                    if (count > bestCount)
                    {
                        bestCount = count;
                        bestNum = input[i];
                    }
                }
                else
                {
                    count = 1;
                }
                if (count > bestCount)
                {
                    bestCount = count;
                    bestNum = input[i];
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write($"{bestNum} ");
            }
            Console.WriteLine();
        }
    }
}
