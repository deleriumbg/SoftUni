using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_in_Range_1_to_100
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Еnter a number in the range [1...100]:");
                int n = int.Parse(Console.ReadLine());

                if (n >= 1 && n <= 100)
                {
                    Console.WriteLine($"The number is: {n}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}
