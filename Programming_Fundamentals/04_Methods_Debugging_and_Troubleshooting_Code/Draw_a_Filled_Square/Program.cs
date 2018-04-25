using System;

namespace Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintHeaderAndFooter(n);
            PrintBody(n);
            PrintHeaderAndFooter(n);
        }

        static void PrintHeaderAndFooter(int number)
        {
            string headerFooter = new string('-', 2 * number);
            Console.WriteLine(headerFooter);
        }

        static void PrintBody(int number)
        {
            for (int row = 2; row <= number - 1 ; row++)
            {
                Console.Write('-');
                for (int i = 1; i <= number - 1; i++)
                {
                    Console.Write("\\/");
                }
                Console.Write('-');
                Console.WriteLine();
            }
        }
    }
}
