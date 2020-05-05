using System;

namespace Cup
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 5 * n;
            for (int i = 0; i < n + 1; i++)
            {
                if (i < n / 2)
                {
                    Console.WriteLine($"{new string('.', n + i)}{new string('#', (3 * n) - 2 * i)}{new string('.', n + i)}");
                }
                else
                {
                    Console.WriteLine($"{new string('.', n + i)}#{new string('.', (3 * n - 2) - 2 * i)}#{new string('.', n + i)}");
                }
                
            }
            Console.WriteLine($"{new string('.', 2 * n)}{new string('#', n)}{new string('.', 2 * n)}");
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"{new string('.', 2 * n - 2)}{new string('#', n + 4)}{new string('.', 2 * n - 2)}");
            }
            Console.WriteLine($"{new string('.', (width - 10) / 2)}D^A^N^C^E^{new string('.', (width - 10) / 2)}");
            for (int i = 0; i < n / 2 + 1; i++)
            {
                Console.WriteLine($"{new string('.', 2 * n - 2)}{new string('#', n + 4)}{new string('.', 2 * n - 2)}");
            }
        }
    }
}
