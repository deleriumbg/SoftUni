using System;

namespace Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n = Math.Abs(n);
            Console.WriteLine(GetMultipleOfEvenAndOdd(n));
        }

        static int GetMultipleOfEvenAndOdd(int n)
        {
            int sumEvens = GetSumOfEvenNumbers(n);
            int sumOdds = GetSumOfOddNumbers(n);
            int result = sumEvens * sumOdds;
            return result;
        }

        static int GetSumOfEvenNumbers(int n)
        {
            int sumEvens = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                {
                    sumEvens += lastDigit;
                }
                n /= 10;
            }
            return sumEvens;
        }

        static int GetSumOfOddNumbers(int n)
        {
            int sumOdds = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 != 0)
                {
                    sumOdds += lastDigit;
                }
                n /= 10;
            }
            return sumOdds;
        }
    }
}
