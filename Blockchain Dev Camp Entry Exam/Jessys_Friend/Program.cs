using System;

namespace Jessys_Friend
{
    class Program
    {
        static void Main(string[] args)
        {
            int startInterval = int.Parse(Console.ReadLine());
            int endInterval = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationCounter = 0;

            for (int i = startInterval; i <= endInterval; i++)
            {
                for (int j = startInterval; j <= endInterval; j++)
                {
                    combinationCounter++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinationCounter} ({i} + {j} = {magicNumber})");
                        Environment.Exit(0);
                    }
                }
            }
            Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNumber}");
        }
    }
}
