using System;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int currentNum = 1; currentNum <= input; currentNum++)
            {
                bool isSpecial = false;
                int sumOfDigits = 0;
                int digits = currentNum;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits /= 10;
                }
                if (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine($"{currentNum} -> {isSpecial}");
            }
        }
    }
}
