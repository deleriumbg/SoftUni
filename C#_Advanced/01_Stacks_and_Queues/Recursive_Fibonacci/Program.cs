using System;

namespace Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            memoization = new long[input + 1];
            Console.WriteLine(Fibonacci(input));
        }

        private static long[] memoization;

        private static long Fibonacci(long n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memoization[n] == 0)
            {
                memoization[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            return memoization[n];
        }
    }
}
