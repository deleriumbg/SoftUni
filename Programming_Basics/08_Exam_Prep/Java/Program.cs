using System;

namespace Java
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 3 * n + 6;
            int height = 3 * n + 1;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{new string(' ', n)}~ ~ ~");
            }
            Console.WriteLine($"{new string('=', width - 1)}");
            for (int i = 0; i < n - 2; i++)
            {
                if (i == (n - 2) / 2)
                {
                    Console.WriteLine($"|{new string('~', n)}JAVA{new string('~', n)}|{new string(' ', n - 1)}|");
                }
                else
                {
                    Console.WriteLine($"|{new string('~', width - n - 2)}|{new string(' ', n - 1)}|");
                }
            }
            Console.WriteLine($"{new string('=', width - 1)}");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{new string(' ', i)}\\{new string('@', width - n - 2 - (2 * i))}/");
            }
            Console.WriteLine($"{new string('=', 2 * n + 6)}");
        }
    }
}
