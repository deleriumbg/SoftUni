using System;

namespace Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int magical = int.Parse(Console.ReadLine());
            int counter = 0;
            int sum = 0;

            for (int i = M; i >= N; i--)
            {
                for (int j = M; j >= N; j--)
                {
                    sum = i + j;
                    counter++;
                    if (sum == magical)
                    {
                        Console.WriteLine($"Number found! {i} + {j} = {i + j}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations - neither equals {magical}");
        }
    }
}
