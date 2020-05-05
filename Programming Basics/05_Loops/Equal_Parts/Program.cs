using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Parts
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double previousPairSum = 0;
            double currentPairSum = 0;
            double difference = 0;
            double maxDiff = 0;

            for (int i = 0; i < n; i++)
            {
                double firstNumber = double.Parse(Console.ReadLine());
                double secondNumber = double.Parse(Console.ReadLine());

                if (i == 0)
                {
                    previousPairSum = firstNumber + secondNumber;
                }
                else
                {
                    currentPairSum = firstNumber + secondNumber;
                    difference = Math.Abs(currentPairSum - previousPairSum);
                    if (difference > maxDiff)
                    {
                        maxDiff = difference;
                    }
                    previousPairSum = currentPairSum;
                }
            }

            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value = {previousPairSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff = {maxDiff}");
            }
        }
    }
}
