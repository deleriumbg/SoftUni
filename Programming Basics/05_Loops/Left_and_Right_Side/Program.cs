using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Left_and_Right_Side
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftSum = 0;
            for (int i = 1; i <= n; i++)
            {
                int left = int.Parse(Console.ReadLine());
                leftSum = leftSum + left;
            }
            int rightSum = 0;
            for (int i = 1; i <= n; i++)
            {
                int right = int.Parse(Console.ReadLine());
                rightSum += right;
            }
            int sum = Math.Abs(leftSum - rightSum);
            if (sum == 0)
            {
                Console.WriteLine($"Yes, sum = {leftSum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {sum}");
            }
        }
    }
}
