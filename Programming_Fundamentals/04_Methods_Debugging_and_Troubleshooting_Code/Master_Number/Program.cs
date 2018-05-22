using System;
using System.Linq;

namespace Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            for (int num = 1; num <= range; num++)
            {
                if (SumOfDigits(num) && IsPalindrome(num.ToString()) && ContainsEvenDigit(num.ToString()))
                {
                    Console.WriteLine(num);
                }
            }
        }

        private static bool ContainsEvenDigit(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if ((int.Parse(num[i].ToString()) % 2) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool SumOfDigits(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum % 7 == 0;
        }

        private static bool IsPalindrome(string num)
        {
            return num.SequenceEqual(num.Reverse());
        }
    }
}
