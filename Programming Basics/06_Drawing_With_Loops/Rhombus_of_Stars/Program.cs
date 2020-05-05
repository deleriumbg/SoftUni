using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 1; row <= n; row++)
            {
                for (int space = 0; space < n - row; space++)
                {
                    Console.Write(" ");
                }
                Console.Write("* ");
                for (int i = 0; i < row - 1; i++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            for (int row = 1; row <= n - 1; row++)
            {
                for (int space = 0; space < row; space++)
                {
                    Console.Write(" ");
                }
                for (int i = 1; i <= n - row; i++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
