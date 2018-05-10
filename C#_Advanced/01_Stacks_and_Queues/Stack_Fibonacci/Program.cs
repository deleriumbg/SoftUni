using System;
using System.Collections.Generic;

namespace Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);
            if (n <= 2)
            {
                Console.WriteLine(1);
                Environment.Exit(0);
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    long firstElement = stack.Pop();
                    long secondElement = stack.Pop();
                    stack.Push(firstElement);
                    stack.Push(firstElement + secondElement);
                }
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
