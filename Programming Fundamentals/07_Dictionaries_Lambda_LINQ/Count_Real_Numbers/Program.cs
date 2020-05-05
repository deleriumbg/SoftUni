using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            double[] input = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (counts.ContainsKey(input[i]) == false)
                {
                    counts.Add(input[i], 1);
                }
                else
                {
                    counts[input[i]]++;
                }
            }
            foreach (var num in counts)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
