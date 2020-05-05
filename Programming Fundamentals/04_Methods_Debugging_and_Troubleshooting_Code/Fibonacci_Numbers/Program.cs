using System;

namespace Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateFibonacci(n));
        }

        static int CalculateFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            int first = 1;
            int second = 1;
            int newNum = 0;
            for (int i = 2; i <= n; i++)
            {
                newNum = first + second;
                first = second;
                second = newNum;
            }
            return newNum;
        }
    }
}
