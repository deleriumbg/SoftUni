using System;
using System.Linq;

namespace Lego_Blocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int totalCells = 0;

            int[][] firstPiece = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                firstPiece[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                totalCells += firstPiece[row].Length;
            }

            int[][] secondPiece = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                secondPiece[row] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
                totalCells += secondPiece[row].Length;
            }

            int firstRowLength = firstPiece[0].Length + secondPiece[0].Length;

            bool isFit = true;
            for (int row = 1; row < rows; row++)
            {
                if (firstPiece[row].Length + secondPiece[row].Length != firstRowLength)
                {
                    isFit = false;
                }
            }

            if (isFit)
            {
                PrintResult(firstPiece, secondPiece, rows);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }

        private static void PrintResult(int[][] firstPiece, int[][] secondPiece, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine($"[{string.Join(", ", firstPiece[row])}, {string.Join(", ", secondPiece[row])}]");
            }
        }
    }
}
