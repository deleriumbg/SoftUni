using System;
using System.Linq;

namespace Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = input.Length / 4;
            int[] sum = new int[2 * k];

            int[] bottomRow = new int[2 * k];
            for (int i = 0; i < 2 * k; i++)
            {
                bottomRow[i] = input[i + k];
            }

            int[] topLeftRow = new int[k];
            int[] topRightRow = new int[k];
            for (int i = 0; i < k; i++)
            {
                topLeftRow[i] = input[k - 1 - i];
                topRightRow[i] = input[4 * k - 1 - i];
            }

            //Merging 2 Arrays
            int[] topRow = topLeftRow.Concat(topRightRow).ToArray();

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = bottomRow[i] + topRow[i];
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
