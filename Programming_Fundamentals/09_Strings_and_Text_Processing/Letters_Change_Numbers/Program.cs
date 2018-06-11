using System;

namespace Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(new char[] { ' ', '\t' },StringSplitOptions.RemoveEmptyEntries);
            double sum = 0.0;

            foreach (var word in strings)
            {
                char[] sequence = word.Trim().ToCharArray();

                double wordSum = CalculateWordSum(sequence);
                sum += wordSum;
            }

            Console.WriteLine($"{sum:f2}");
        }

        private static double CalculateWordSum(char[] sequence)
        {
            char firstLetter = sequence[0];
            char lastLetter = sequence[sequence.Length - 1];

            char[] numberArr = new char[sequence.Length - 2];
            for (int i = 1; i <= sequence.Length - 2; i++)
            {
                numberArr[i - 1] = sequence[i];
            }
            double number = double.Parse(new string(numberArr));

            if (char.IsUpper(firstLetter))
            {
                number /= (firstLetter - 64);
            }
            else
            {
                number *= (firstLetter - 96);
            }

            if (char.IsUpper(lastLetter))
            {
                number -= (lastLetter - 64);
            }
            else
            {
                number += (lastLetter - 96);
            }

            return number;
        }
    }
}
