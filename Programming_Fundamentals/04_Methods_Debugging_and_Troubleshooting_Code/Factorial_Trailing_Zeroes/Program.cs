using System;
using System.Numerics;

namespace Factorial_Trailing_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());
            BigInteger factorial = GetFactorial(n);
            int counter = 0;
            while (true)
            {
                if (factorial % 10 == 0)
                {
                    counter++;
                    factorial /= 10;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(counter);
        }

        static BigInteger GetFactorial(BigInteger n)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
