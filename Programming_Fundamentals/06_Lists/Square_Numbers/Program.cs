using System;
using System.Collections.Generic;
using System.Linq;

namespace Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            input.Sort();
            input.Reverse();
            List<int> result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (Math.Sqrt(input[i]) == (int)Math.Sqrt(input[i]))
                {
                    result.Add(input[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
