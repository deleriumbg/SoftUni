using System;
using System.Linq;

namespace Jedi_Galaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimensions[0];
            int col = dimensions[1];
            int[,] matrix = FillGalaxyMatrix(row, col);

            string command = Console.ReadLine();
            long sum = 0;
            sum = CalculateTotalSum(command, matrix, sum);
            Console.WriteLine(sum);
        }

        private static long CalculateTotalSum(string command, int[,] matrix, long sum)
        {
            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                EvilDestroyingStars(matrix, evilCoordinates);
                sum = IvoCollectingStars(matrix, sum, ivoCoordinates);
                command = Console.ReadLine();
            }
            return sum;
        }

        private static long IvoCollectingStars(int[,] matrix, long sum, int[] ivoCoordinates)
        {
            int ivoRows = ivoCoordinates[0];
            int ivoCols = ivoCoordinates[1];

            while (ivoRows >= 0 && ivoCols < matrix.GetLength(1))
            {
                if (ivoRows >= 0 && ivoRows < matrix.GetLength(0) && ivoCols >= 0 && ivoCols < matrix.GetLength(1))
                {
                    sum += matrix[ivoRows, ivoCols];
                }

                ivoCols++;
                ivoRows--;
            }
            return sum;
        }

        private static void EvilDestroyingStars(int[,] matrix, int[] evilCoordinates)
        {
            int evilRows = evilCoordinates[0];
            int evilCols = evilCoordinates[1];

            while (evilRows >= 0 && evilCols >= 0)
            {
                if (evilRows >= 0 && evilRows < matrix.GetLength(0) && evilCols >= 0 && evilCols < matrix.GetLength(1))
                {
                    matrix[evilRows, evilCols] = 0;
                }

                evilRows--;
                evilCols--;
            }
        }

        private static int[,] FillGalaxyMatrix(int row, int col)
        {
            int[,] matrix = new int[row, col];
            int value = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = value++;
                }
            }
            return matrix;
        }
    }
}
