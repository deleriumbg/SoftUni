using System;

namespace Crown
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = (2 * n) - 1;
            int height = (n / 2) + 4;

            Console.WriteLine($"@{new string(' ', n - 2)}@{new string(' ', n - 2)}@");
            for (int i = 0; i <= n / 2; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"**{new string(' ', n - 3)}*{new string(' ', n - 3)}**");
                }
                else if (i == n / 2 - 1)
                {
                    Console.WriteLine($"*{new string('.', i)}*{new string('.', n - 3)}*{new string('.', i)}*");
                }
                else if (i == n / 2)
                {
                    Console.WriteLine($"*{new string('.', n / 2)}{new string('*', n / 2 - 2)}.{new string('*', n / 2 - 2)}{new string('.', n / 2)}*");
                }
                else
                {
                    Console.WriteLine($"*{new string('.', i)}*{new string(' ', n - 3 - 2 * i)}*{new string('.', 2 * i - 1)}*{new string(' ', n - 3 - 2 * i)}*{new string('.', i)}*");
                }
                
            }
            Console.WriteLine($"{new string('*', width)}");
            Console.WriteLine($"{new string('*', width)}");
        }
    }
}
