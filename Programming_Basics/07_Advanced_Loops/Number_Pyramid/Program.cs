using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int counter = 1;

            for (int row = 1; counter <= n; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    if (counter <= n)
                    {
                        Console.Write($"{counter} ");
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
}
