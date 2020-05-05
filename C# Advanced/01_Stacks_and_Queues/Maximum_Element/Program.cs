using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> stackMax = new Stack<int>();
            StringBuilder result = new StringBuilder();
            stackMax.Push(int.MinValue);

            for (int i = 0; i < n; i++)
            {
                int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                switch (commands[0])
                {
                    case 1:
                        stack.Push(commands[1]);
                        if (commands[1] >= stackMax.Peek())
                        {
                            stackMax.Push(commands[1]);
                        }
                        break;
                    case 2:
                        int popped = stack.Pop();
                        if (stackMax.Peek() == popped)
                        {
                            stackMax.Pop();
                        }
                        break;
                    case 3:
                        result.Append($"{stackMax.Peek()}{Environment.NewLine}");
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
