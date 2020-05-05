using System;

namespace ASCII_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numbersSum = 0;
            int capitalsSum = 0;
            int lowercaseSum = 0;
            int othersSum = 0;
            string numbersStr = "";
            string capitalsStr = "";
            string lowercaseStr = "";
            string othersStr = "";

            for (int i = 0; i < n; i++)
            {
                char input = char.Parse(Console.ReadLine());
                int output = (int)input;
                if (output >= 48 && output <= 57)
                {
                    numbersSum += output;
                    numbersStr += input;
                }
                else if (output >= 65 && output <= 90)
                {
                    capitalsSum += output;
                    capitalsStr += input;
                }
                else if (output >= 97 && output <= 122)
                {
                    lowercaseSum += output;
                    lowercaseStr += input;
                }
                else
                {
                    othersSum += output;
                    othersStr += input;
                }
            }
            int biggestSum = Math.Max(numbersSum, Math.Max(capitalsSum, Math.Max(lowercaseSum, othersSum)));
            string biggestStr = "";
            if (biggestSum == numbersSum)
            {
                biggestStr = numbersStr;
            }
            else if (biggestSum == capitalsSum)
            {
                biggestStr = capitalsStr;
            }
            else if (biggestSum == lowercaseSum)
            {
                biggestStr = lowercaseStr;
            }
            else if (biggestSum == othersSum)
            {
                biggestStr = othersStr;
            }
            Console.WriteLine($"Biggest ASCII sum is:{biggestSum}\r\nCombination of characters is:{biggestStr}");
        }
    }
}
