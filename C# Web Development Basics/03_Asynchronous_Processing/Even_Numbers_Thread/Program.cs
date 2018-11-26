using System;
using System.Linq;
using System.Threading;

namespace Even_Numbers_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = input[0];
            int end = input[1];

            Thread evens = new Thread(() => PrintEvenNumbers(start, end));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
