using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            input.Sort();
            int current = input[0];
            int count = 1;

            for (int i = 1; i < input.Count; i++)
            {
                if (current == input[i])
                {
                    count++;
                }
                else
                {
                    Console.WriteLine($"{current} -> {count}");
                    current = input[i];
                    count = 1;
                }
            }
            Console.WriteLine($"{current} -> {count}");
        }
    }
}
