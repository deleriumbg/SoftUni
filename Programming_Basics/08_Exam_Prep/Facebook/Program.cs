using System;

namespace Facebook
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int side = 2 * n + 2;
            Console.WriteLine($"{new string('#', 2 * n + 2)}");
            for (int i = 0; i < (side - 1) / 2; i++)
            {
                Console.WriteLine($"#{new string(' ', i)}#{new string(' ', side - 4 - (2 * i))}#{new string(' ', i)}#");
            }
            for (int i = ((side - 1) / 2) - 1; i >= 0; i--)
            {
                Console.WriteLine($"#{new string(' ', i)}#{new string(' ', side - 4 - (2 * i))}#{new string(' ', i)}#");
            }
            Console.WriteLine($"{new string('#', 2 * n + 2)}");
        }
    }
}
