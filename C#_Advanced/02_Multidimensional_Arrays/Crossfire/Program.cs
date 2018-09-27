using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        private static List<List<int>> matrix = new List<List<int>>();

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            FillMatrix(rows, columns);
            
            string command = Console.ReadLine();
            while (command != "Nuke it from orbit")
            {
                int[] coordinates = command.Split().Select(int.Parse).ToArray();
                
                Shoot(coordinates);

                command = Console.ReadLine();
            }

            PrintResult();
        }

        private static void Shoot(int[] coordinates)
        {
            int targetRow = coordinates[0];
            int targetCol = coordinates[1];
            int radius = coordinates[2];

            for (int row = targetRow - radius; row <= targetRow + radius; row++)
            {
                if (IsInside(row, targetCol))
                {
                    matrix[row][targetCol] = 0;
                }
            }

            for (int col = targetCol - radius; col <= targetCol + radius; col++)
            {
                if (IsInside(targetRow, col))
                {
                    matrix[targetRow][col] = 0;
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(x => x == 0);
                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Count && col >= 0 && col < matrix[row].Count;
        }

        private static void FillMatrix(int rows, int columns)
        {
            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                List<int> currentRow = new List<int>();
                for (int col = 0; col < columns; col++)
                {
                    currentRow.Add(counter++);
                }
                matrix.Add(currentRow);
            }
        }

        private static void PrintResult()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
