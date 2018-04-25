using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string topRow = new string('*', 2 * n) + new string(' ', n) + new string('*', 2 * n);
            Console.WriteLine(topRow);

            for (int row = 1; row <= n - 2; row++)
            {
                string midRows = '*' + new string('/', 2 * n - 2) + '*' + new string(' ', n) + '*' + new string('/', 2 * n - 2) + '*';
                if (row == (n - 1) / 2)
                {
                    string frameRow = '*' + new string('/', 2 * n - 2) + '*' + new string('|', n) + '*' + new string('/', 2 * n - 2) + '*';
                    Console.WriteLine(frameRow);
                }
                else
                {
                    Console.WriteLine(midRows);
                }
            }
            Console.WriteLine(topRow);
        }
    }
}
