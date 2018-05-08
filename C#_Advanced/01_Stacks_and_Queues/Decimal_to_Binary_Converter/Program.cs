using System;
using System.Collections.Generic;

namespace Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> binary = new Stack<int>();
            if (n == 0)
            {
                Console.WriteLine(0);
            }
            while (n > 0)
            {
                int remainder = n % 2;
                n /= 2;
                binary.Push(remainder);
                
            }
            while (binary.Count > 0)
            {
                Console.Write(binary.Pop());
            }
        }
    }
}
