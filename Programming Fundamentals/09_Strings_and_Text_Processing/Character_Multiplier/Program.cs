using System;

namespace Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string firstWord = input[0];
            string secondWord = input[1];
            int sum = 0;
            for (int i = 0; i < Math.Min(firstWord.Length, secondWord.Length); i++)
            {
                sum += firstWord[i] * secondWord[i];
            }
            for (int i = Math.Min(firstWord.Length, secondWord.Length); i < Math.Max(firstWord.Length, secondWord.Length); i++)
            {
                try
                {
                    sum += firstWord[i];
                }
                catch
                {
                    sum += secondWord[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
