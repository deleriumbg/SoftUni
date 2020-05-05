using System;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int currentNum = 1; currentNum <= n; currentNum++)
            {
                bool isSpecial = false;
                int sumDigits = 0;
                int digits = currentNum;
                while (digits > 0)
                {
                    sumDigits += digits % 10;
                    digits = digits / 10;
                }
                if ((sumDigits == 5) || (sumDigits == 7) || (sumDigits == 11))
                {
                    isSpecial = true;
                }
                Console.WriteLine($"{currentNum} -> {isSpecial}");
            }
        }
    }
}
