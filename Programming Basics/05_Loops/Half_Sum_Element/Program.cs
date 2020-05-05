using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int max = 0;

            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum = sum + num;
                if (num > max)
                {
                    max = num;
                }
            }
            if (sum == 2 * max)
            {
                Console.WriteLine($"Yes Sum = {max}");
            }
            else
            {
                Console.WriteLine($"No Diff = {Math.Abs(max-(sum-max))}");
            }
        }
    }
}
