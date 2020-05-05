using System;

namespace Christmas_Sock
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n + 2;
            int height = 3 * n + 3;
            Console.WriteLine($"|{new string('-', width - 2)}|");
            Console.WriteLine($"|{new string('*', width - 2)}|");
            Console.WriteLine($"|{new string('-', width - 2)}|");
            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine($"|{new string('-', n - 1 - i)}{new string('~', 2 + 2 * i)}{new string('-', n - 1 - i)}|");
            }
            for (int i = n - 3; i >= 0; i--)
            {
                Console.WriteLine($"|{new string('-', n - 1 - i)}{new string('~', 2 + 2 * i)}{new string('-', n - 1 - i)}|");
            }
            int bottomHeight = height - 2 * n;
            for (int i = 0; i < bottomHeight; i++)
            {
                if (i == n / 2)
                {
                    Console.WriteLine($"{new string('-', i)}\\{new string('.', n - 2)}MERRY{new string('.', n - 2)}\\");
                }
                else if (i == (n / 2) + 2)
                {
                    Console.WriteLine($"{new string('-', i)}\\{new string('.', n - 2)}X-MAS{new string('.', n - 2)}\\");
                }
                else if (i == bottomHeight - 1)
                {
                    Console.WriteLine($"{new string('-', i)}\\{new string('_', width - 1)})");
                }
                else
                {
                    Console.WriteLine($"{new string('-', i)}\\{new string('.', width - 1)}\\");
                }
            }
        }
    }
}
