using System;

namespace Draw_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = (4 * n) + 1;
            int height = (2 * n) + 1;
            for (int i = 0; i < height; i++)
            {
                if (i == n / 2 + 1)
                {
                    Console.WriteLine($"{new string('.', i)}{new string('#', (2 * n) - 2 * i + 1)}{new string(' ', i - 2)}(@){new string(' ', i - 2)}{new string('#', (2 * n) - 2 * i + 1)}{new string('.', i)}");
                }
                else if (i >= 1 && i <= n)
                {
                    Console.WriteLine($"{new string('.', i)}{new string('#', (2 * n) - 2 * i + 1)}{new string(' ', width - (4 * n) + 2 * i - 2)}{new string('#', (2 * n) - 2 * i + 1)}{new string('.', i)}");
                }
                else
                {
                    Console.WriteLine($"{new string('.', i)}{new string('#', width - 2 * i)}{new string('.', i)}");
                }
            }
        }
    }
}
