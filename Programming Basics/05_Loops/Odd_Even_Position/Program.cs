using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double OddSum = 0;
            double OddMin = 1000000000.0;
            double OddMax = -1000000000.0;
            double EvenSum = 0;
            double EvenMin = 1000000000.0;
            double EvenMax = -1000000000.0;

            for (int i = 1; i <= n; i++)
            {
                double nextNumber = double.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    OddSum = OddSum + nextNumber;
                    if (nextNumber > OddMax)
                    {
                        OddMax = nextNumber;
                    }
                    if (nextNumber < OddMin)
                    {
                        OddMin = nextNumber;
                    }
                }
                else
                {
                    EvenSum = EvenSum + nextNumber;
                    if (nextNumber > EvenMax)
                    {
                        EvenMax = nextNumber;
                    }
                    if (nextNumber < EvenMin)
                    {
                        EvenMin = nextNumber;
                    }
                }
            }
            if (n == 0)
            {
                Console.WriteLine("OddSum = 0, OddMin= No, OddMax = No, EvenSum = 0, EvenMin = No, EvenMax = No");
            }
            else if (n == 1)
            {
                Console.WriteLine($"OddSum = {OddSum}, OddMin= {OddMin}, OddMax = {OddMax}, EvenSum = 0, EvenMin = No, EvenMax = No");
            }
            else
            {
                Console.WriteLine($"OddSum = {OddSum}, OddMin= {OddMin}, OddMax = {OddMax}, EvenSum = {EvenSum}, EvenMin = {EvenMin}, EvenMax = {EvenMax}");
            }
        }
    }
}
