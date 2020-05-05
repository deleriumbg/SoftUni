using System;

namespace Rocket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number:");
            int n = int.Parse(Console.ReadLine());
            DrawRocket(n);
        }

        private static void DrawRocket(int n)
        {
            for (int i = 0; i < n * 2 - 1; i++)
            {
                Console.WriteLine($"{new string(' ', 2 * n - 1 - i)}{new string('/', i + 1)}**{new string('\\', i + 1)}");
            }

            PrintEqualsAndStars(n);
            PrintTopPart(n);
            PrintBottomPart(n);
            PrintEqualsAndStars(n);
            PrintBottomPart(n);
            PrintTopPart(n);
            PrintEqualsAndStars(n);

            for (int i = 0; i < n * 2 - 1; i++)
            {
                if (i == n * 2 - 2 && n != 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (i == n * 2 - 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine($"{new string(' ', 2 * n - 1 - i)}{new string('/', i + 1)}**{new string('\\', i + 1)}");
            }
        }

        private static void PrintBottomPart(int n)
        {
            for (int i = n; i > 0; i--)
            {
                Console.Write($"|{new string('.', n - i)}");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("\\/");
                }
                Console.Write($"{new string('.', (n - i) * 2)}");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("\\/");
                }
                Console.Write($"{new string('.', n - i)}");
                Console.WriteLine("|");
            }
        }

        private static void PrintTopPart(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"|{new string('.', n - 1 - i)}");
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("/\\");
                }
                Console.Write($"{new string('.', (n - 1 - i) * 2)}");
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("/\\");
                }
                Console.Write($"{new string('.', n - 1 - i)}");
                Console.WriteLine("|");
            }
        }

        private static void PrintEqualsAndStars(int n)
        {
            Console.Write("+");
            for (int i = 0; i < n * 2; i++)
            {
                Console.Write("*=");
            }
            Console.WriteLine("+");
        }
    }
}
