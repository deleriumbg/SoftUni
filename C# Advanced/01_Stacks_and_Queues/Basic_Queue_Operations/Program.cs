using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < tokens[1]; i++)
            {
                queue.Dequeue();
            }
            Console.WriteLine(queue.Count == 0 ? "0" : queue.Contains(tokens[2]) ? "true" : $"{queue.Min()}");
        }
    }
}
