using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] openBrackets = { '(', '{', '[' };
            char[] closedBrackets = { ')', '}', ']' };
            Stack<char> stack = new Stack<char>();
            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (openBrackets.Contains(input[i]))
                {
                    stack.Push(input[i]);
                }
                
                else if (closedBrackets.Contains(input[i]))
                {
                    int index = Array.IndexOf(closedBrackets, input[i]);
                    var popped = stack.Pop();
                    if (popped != openBrackets[index])
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
