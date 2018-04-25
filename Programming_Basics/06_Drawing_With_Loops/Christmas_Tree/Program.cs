using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christmas_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string middle = " | ";

            for (int i = 0; i <= n; i++)
            {
                for (int spaces = 0; spaces < n - i; spaces++)
                {
                    Console.Write(" ");
                }
         
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }

                Console.Write(middle);

                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
