using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('|').ToList();
            input.Reverse();

            for (int i = 0; i < input.Count; i++)
            {
                string[] arr = input[i].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string joined = string.Join(" ", arr);
                Console.Write($"{joined} ");
            }
            Console.WriteLine();
        }
    }
}
