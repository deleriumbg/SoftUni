using System;

namespace Parallelepiped
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 3 * n + 1;
            int height = 4 * n + 4;

            Console.WriteLine($"+{new string('~', n - 2)}+{new string('.', width - n)}");
            for (int i = 0; i < 2 * n + 1; i++)
            {
                Console.WriteLine($"|{new string('.', i)}\\{new string('~', n - 2)}\\{new string('.', width - n - 1 - i)}");
            }
            for (int i = 0; i < 2 * n + 1; i++)
            {
                Console.WriteLine($"{new string('.', i)}\\{new string('.', 2 * n - i)}|{new string('~', n - 2)}|");
            }
            Console.WriteLine($"{new string('.', width - n)}+{new string('~', n - 2)}+");
        }
    }
}
