using System;

namespace PIN
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 6 * n + 10;
            int height = 2 * n + 2;

            Console.WriteLine($"/`{new string('P', 2 * n)}{new string(' ', n)}/`I{new string(' ', n)}/`N{new string(' ', 2 * n + 1)}N");
            for (int i = 0; i < height - 1; i++)
            {
                if (i < n - 1)
                {
                    Console.WriteLine($"| P{new string(' ', 2 * n - 2)}P{new string(' ', n)}| I{new string(' ', n)}| N{new string(' ', i)}N{new string(' ', 2 * n - i)}N");
                }
                else if (i == n - 1)
                {
                    Console.WriteLine($"| {new string('P', 2 * n)}{new string(' ', n)}| I{new string(' ', n)}| N{new string(' ', i)}N{new string(' ', 2 * n - i)}N");
                }
                else if (i == height - 2)
                {
                    Console.WriteLine($"\\_{new string('P', n / 2)}{new string(' ', 2 * n + (n + 1 )/ 2)}\\_I{new string(' ', n)}\\_N{new string(' ', i)}N{new string(' ', 2 * n - i)}N");
                }
                else
                {
                    Console.WriteLine($"| {new string('P', n / 2)}{new string(' ', 2 * n + (n + 1) / 2)}| I{new string(' ', n)}| N{new string(' ', i)}N{new string(' ', 2 * n - i)}N");
                }
            }
            
        }
    }
}
