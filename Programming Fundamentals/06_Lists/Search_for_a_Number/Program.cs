using System;
using System.Collections.Generic;
using System.Linq;

namespace Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> first = numbers.Take(commands[0]).ToList();
            int index = 0;
            int count = commands[1];
            first.RemoveRange(index, count);
            bool isPresent = first.Contains(commands[2]);
            if (isPresent)
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
