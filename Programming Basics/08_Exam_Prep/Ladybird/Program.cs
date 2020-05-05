using System;

namespace Ladybird
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = 2 * n + 1;
            int topLeftRight = (width - 5) / 2;
            Console.WriteLine($"{new string(' ', topLeftRight)}@   @{new string(' ', topLeftRight)}");
            Console.WriteLine($"{new string(' ', topLeftRight + 1)}\\_/{new string(' ', topLeftRight + 1)}");
            Console.WriteLine($"{new string(' ', topLeftRight + 1)}/ \\{new string(' ', topLeftRight + 1)}");
            Console.WriteLine($"{new string(' ', topLeftRight + 1)}|_|{new string(' ', topLeftRight + 1)}");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{new string(' ', topLeftRight + 1 - i)}/{new string(' ', i)}|{new string(' ', i)}\\{new string(' ', topLeftRight + 1 - i)}");
            }
            int spotsDistance = (n - 2) / 2;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"|{new string(' ', spotsDistance)}@{new string(' ', (n - 1) / 2)}|{new string(' ', (n - 1) / 2)}@{new string(' ', spotsDistance)}|");
            }
            if (n == 2)
            {
                Console.WriteLine($" ^|^ ");
            }
            else
            {
                for (int i = 0; i < n / 2; i++)
                {
                    Console.WriteLine($"{new string(' ', i)}\\{new string(' ', (width / 2) - 1 - i)}|{new string(' ', (width / 2) - 1 - i)}/{new string(' ', i)}");
                }
                Console.WriteLine($"{new string(' ', (n + 1) / 2)}{new string('^', n / 2)}|{new string('^', n / 2)}{new string(' ', (n + 1) / 2)}");
            }
        }
    }
}
