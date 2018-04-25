using System;
using System.Linq;

namespace Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isFound = false;

            for (int i = 0; i < input.Length; i++)
            {
                int[] leftSum = input.Take(i).ToArray();
                int[] rightSum = input.Skip(i + 1).ToArray();
                if (leftSum.Sum() == rightSum.Sum())
                {
                    Console.WriteLine(i);
                    isFound = true;
                }
            }
            if (!isFound)
            {
                Console.WriteLine("no");
            }
        }
    }
}
