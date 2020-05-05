using System;

namespace Christmas_Toy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 5 * n;
            int height = 2 * n + 3;

            Console.WriteLine($"{new string ('-', 2 * n)}{new string ('*', n)}{new string('-', 2 * n)}");
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"{new string('-', 2 * n - 2 - (2 *i))}*{new string('*', i)}{new string('&', n+ 2 + (2 * i))}{new string('*', i)}*{new string('-', 2 * n - 2 - (2 * i))}");
            }
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"{new string('-', n - 1 - i)}**{new string('~', width - 4 - 2 *(n - 1 - i))}**{new string('-', n - 1 - i)}");
            }
            Console.WriteLine($"{new string('-', n / 2)}*{new string('|', width - (n + 2))}*{new string('-', n / 2)}");
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Console.WriteLine($"{new string('-', n - 1 - i)}**{new string('~', width - 4 - 2 * (n - 1 - i))}**{new string('-', n - 1 - i)}");
            }
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Console.WriteLine($"{new string('-', 2 * n - 2 - (2 * i))}*{new string('*', i)}{new string('&', n + 2 + (2 * i))}{new string('*', i)}*{new string('-', 2 * n - 2 - (2 * i))}");
            }
            Console.WriteLine($"{new string('-', 2 * n)}{new string('*', n)}{new string('-', 2 * n)}");
        }
    }
}
