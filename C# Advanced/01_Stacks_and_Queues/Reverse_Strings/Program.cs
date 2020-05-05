using System;
using System.Collections.Generic;

namespace Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            Stack<char> stack = new Stack<char>(input);
            foreach (var item in input)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
