using System;

namespace Hourglass
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n + 1;

            Console.WriteLine($"{new string('*', width)}");
            Console.WriteLine($".*{new string(' ', width - 4)}*.");
            for (int i = 2; i < n; i++)
            {
                Console.WriteLine($"{new string('.', i)}*{new string('@', width - 2 - 2 * i)}*{new string('.', i)}");
            }
            Console.WriteLine($"{new string('.', n)}*{new string('.', n)}");
            for (int i = n - 1; i >= 2; i--)
            {
                Console.WriteLine($"{new string('.', i)}*{new string(' ', n -1 - i)}@{new string(' ', n - 1 - i)}*{new string('.', i)}");
            }
            Console.WriteLine($".*{new string('@', width - 4)}*.");
            Console.WriteLine($"{new string('*', width)}");
        }
    }
}
