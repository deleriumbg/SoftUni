using System;

namespace Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n + 3;
            int height = 2 * n + 1;

            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine($"{new string('.', i)}*{new string('.', n - i)}*{new string('.', n - i)}*{new string('.', i)}");
            }
            Console.WriteLine($"{new string('.', n - 1)}*****{new string('.', n - 1)}");
            Console.WriteLine($"{new string('*', width)}");
            Console.WriteLine($"{new string('.', n - 1)}*****{new string('.', n - 1)}");
            for (int i = n - 2; i >= 0; i--)
            {
                Console.WriteLine($"{new string('.', i)}*{new string('.', n - i)}*{new string('.', n - i)}*{new string('.', i)}");
            }
        }
    }
}
