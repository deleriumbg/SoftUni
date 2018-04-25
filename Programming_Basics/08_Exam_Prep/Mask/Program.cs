using System;

namespace Mask
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = (2 * n) + 2;
            int topLeftRight = (width - 6) / 2;
            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine($"{new string(' ', topLeftRight - i)}/{new string(' ', i)}|  |{new string(' ', i)}\\{new string(' ', topLeftRight - i)}");
            }
            Console.WriteLine(new string('-', width));
            int eyeDistance = (n - 3) / 2;
            Console.WriteLine($"|{new string(' ', eyeDistance)}_{new string(' ', (2 * eyeDistance) + 4)}_{new string(' ', eyeDistance)}|");
            Console.WriteLine($"|{new string(' ', eyeDistance)}@{new string(' ', (2 * eyeDistance) + 4)}@{new string(' ', eyeDistance)}|");
            for (int i = 0; i < (n - 1) / 2; i++)
            {
                Console.WriteLine($"|{new string(' ', width - 2)}|");
            }
            int bottomLeftRight = (2 * n - 4) / 2;
            Console.WriteLine($"|{new string(' ', bottomLeftRight + 1)}OO{new string(' ', bottomLeftRight + 1)}|");
            Console.WriteLine($"|{new string(' ', bottomLeftRight)}/  \\{new string(' ', bottomLeftRight)}|");
            Console.WriteLine($"|{new string(' ', bottomLeftRight)}||||{new string(' ', bottomLeftRight)}|");
            for (int i = 1; i <= n + 1; i++)
            {
                Console.WriteLine($"{new string('\\', i)}{new string('`', width - 2 * i)}{new string('/', i)}");
            }
        }
    }
}
