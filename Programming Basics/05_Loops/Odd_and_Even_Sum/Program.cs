using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odd_and_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 1; i <= n; i++)
            {
                int allNum = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sumEven = sumEven + allNum;
                }
                else
                {
                    sumOdd = sumOdd + allNum;
                }
            }
            int sum = Math.Abs(sumEven - sumOdd);
            if (sum == 0)
            {
                Console.WriteLine($"Yes Sum = {sumEven}");
            }
            else
            {
                Console.WriteLine($"No Diff = {sum}");
            }
        }
    }
}
