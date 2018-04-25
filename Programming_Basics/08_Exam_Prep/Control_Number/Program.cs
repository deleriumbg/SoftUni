using System;

namespace Control_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int control = int.Parse(Console.ReadLine());
            int sum = 0;
            int moves = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = M; j >= 1; j--)
                {
                    sum += i * 2 + j * 3;
                    moves++;
                    if (sum >= control)
                    {
                        Console.WriteLine($"{moves} moves\r\nScore: {sum} >= {control}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{moves} moves");
        }
    }
}
