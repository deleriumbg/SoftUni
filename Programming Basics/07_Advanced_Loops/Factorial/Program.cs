using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int result = 1;

            do
            {
                result *= n;
                n--;
            } while (n > 1);
            Console.WriteLine(result);
        }
    }
}
