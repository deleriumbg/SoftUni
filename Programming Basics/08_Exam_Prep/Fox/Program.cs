using System;

namespace Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n + 3;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{new string('*', i)}\\{new string('-', width - 2 - 2 * i)}/{new string('*', i)}");
            }
            for (int i = 0; i < n / 3; i++)
            {
                Console.WriteLine($"|{new string('*', n / 2 + i)}\\{new string('*', n - 2 * i)}/{new string('*', n / 2 + i)}|");
            }
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"{new string('-', i)}\\{new string('*', width - 2 - 2 * i)}/{new string('-', i)}");
            }
        }
    }
}
