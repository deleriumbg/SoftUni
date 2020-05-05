using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                int[] rowInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            int total1 = getDiagonalSumFromTop(matrix, size);
            int total2 = getDiagonalSumFromBottom(matrix, size);
            Console.WriteLine(Math.Abs(total1 - total2));
        }

        private static int getDiagonalSumFromTop(int[,] matrix, int size)
        {
            int sum = 0;
            for (int i = 0; i < size; i++)
            {
                sum += matrix[i, i];
            }
            return sum;
        }

        private static int getDiagonalSumFromBottom(int[,] matrix, int size)
        {
            int sum = 0;
            for (int i = size - 1; i >= 0; i--)
            {
                sum += matrix[size - i - 1, i];
            }
            return sum;
        }
    }
}
