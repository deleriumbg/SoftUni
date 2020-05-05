using System;

namespace Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = (4 * n) - 4;
            for (int i = 0; i < n - 2; i++)
            {

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*\\");
                }
                Console.Write(new string(' ', width - 4 - (4 * i)));
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("/*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < (2 * n) - 2; i++)
            {
                Console.Write("\\/");
            }
            Console.WriteLine();
            int arrows = (width - 6) / 2;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"{new string('<', arrows)}*|**|*{new string('>', arrows)}");
            }
            for (int i = 0; i < (2 * n) - 2; i++)
            {
                Console.Write("/\\");
            }
            Console.WriteLine();
            for (int i = n - 3; i >= 0; i--)
            {

                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*/");
                }
                Console.Write(new string(' ', width - 4 - (4 * i)));
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("\\*");
                }
                Console.WriteLine();
            }
        }
    }
}
