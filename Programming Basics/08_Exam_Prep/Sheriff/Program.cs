using System;

namespace Sheriff
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 3 * n;
            int height = 2 * n + 8;

            Console.WriteLine($"{new string('.', (width - 1) / 2)}x{new string('.', (width - 1) / 2)}");
            Console.WriteLine($"{new string('.', (width - 3) / 2)}/x\\{new string('.', (width - 3) / 2)}");
            Console.WriteLine($"{new string('.', (width - 3) / 2)}x|x{new string('.', (width - 3) / 2)}");
            for (int i = 0; i < n / 2 + 1; i++)
            {
                Console.WriteLine($"{new string('.', (width - (2 * n + 1)) / 2 - i)}{new string('x', n + i)}|{new string('x', n + i)}{new string('.', (width - (2 * n + 1)) / 2 - i)}");
            }
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Console.WriteLine($"{new string('.', (width - (2 * n + 1)) / 2 - i)}{new string('x', n + i)}|{new string('x', n + i)}{new string('.', (width - (2 * n + 1)) / 2 - i)}");
            }
            Console.WriteLine($"{new string('.', (width - 3) / 2)}/x\\{new string('.', (width - 3) / 2)}");
            Console.WriteLine($"{new string('.', (width - 3) / 2)}\\x/{new string('.', (width - 3) / 2)}");
            for (int i = 0; i < n / 2 + 1; i++)
            {
                Console.WriteLine($"{new string('.', (width - (2 * n + 1)) / 2 - i)}{new string('x', n + i)}|{new string('x', n + i)}{new string('.', (width - (2 * n + 1)) / 2 - i)}");
            }
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Console.WriteLine($"{new string('.', (width - (2 * n + 1)) / 2 - i)}{new string('x', n + i)}|{new string('x', n + i)}{new string('.', (width - (2 * n + 1)) / 2 - i)}");
            }
            Console.WriteLine($"{new string('.', (width - 3) / 2)}x|x{new string('.', (width - 3) / 2)}");
            Console.WriteLine($"{new string('.', (width - 3) / 2)}\\x/{new string('.', (width - 3) / 2)}");
            Console.WriteLine($"{new string('.', (width - 1) / 2)}x{new string('.', (width - 1) / 2)}");
        }
    }
}
