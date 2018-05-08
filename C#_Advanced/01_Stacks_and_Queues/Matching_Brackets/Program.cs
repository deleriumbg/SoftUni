using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> expression = new Stack<int>();

            for (int index = 0; index < input.Length; index++)
            {
                if (input[index] == '(')
                {
                    expression.Push(index);
                }
                else if (input[index] == ')')
                {
                    int indexOpeningBracket = expression.Pop();
                    Console.WriteLine(input.Substring(indexOpeningBracket, index - indexOpeningBracket + 1));
                }
            }
        }
    }
}
