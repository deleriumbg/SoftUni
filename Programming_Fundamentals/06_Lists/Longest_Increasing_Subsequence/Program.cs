using System;
using System.Collections.Generic;
using System.Linq;

namespace Longest_Increasing_Subsequence
{
    class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] length = new int[numbers.Length];
            int[] prev = new int[numbers.Length];
            int maxLength = 0;
            int lastIndex = -1;

            for (int currentNum = 0; currentNum < numbers.Length; currentNum++)
            {
                length[currentNum] = 1;
                prev[currentNum] = -1;

                for (int i = 0; i < currentNum; i++)
                {
                    if (numbers[i] < numbers[currentNum] && length[i] >= length[currentNum])
                    {
                        length[currentNum] = 1 + length[i];
                        prev[currentNum] = i;
                    }
                }

                if (length[currentNum] > maxLength)
                {
                    maxLength = length[currentNum];
                    lastIndex = currentNum;
                }
            }

            List<int> longestSequence = new List<int>();

            for (int i = 0; i < maxLength; i++)
            {
                longestSequence.Add(numbers[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSequence.Reverse();
            Console.WriteLine(string.Join(" ", longestSequence));
        }
    }
}
