using System;
using System.Linq;

namespace Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            int[,] matrix = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            int sum = 0;
            int maxSum = 0;
            int rowMax = 0;
            int colMax = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        rowMax = row;
                        colMax = col;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (row == rowMax && col == colMax)
                    {
                        Console.WriteLine(matrix[row, col] + " " + matrix[row, col + 1]);
                        Console.WriteLine(matrix[row + 1, col] + " " + matrix[row + 1, col + 1]);
                        Console.WriteLine(maxSum);
                        break;
                    }
                }
            }
        }
    }
}
