using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbers = new Stack<int>(input);

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"{numbers.Pop()} ");
            }
            Console.WriteLine();
        }
    }
}
