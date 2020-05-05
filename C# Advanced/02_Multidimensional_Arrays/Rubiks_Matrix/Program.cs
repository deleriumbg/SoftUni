using System;
using System.Linq;

namespace Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            int[,] rubiksMatrix = new int[rows, columns];

            FillMatrix(rubiksMatrix);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandInput = Console.ReadLine().Split();
                int rowColIndex = int.Parse(commandInput[0]);
                string direction = commandInput[1];
                int steps = int.Parse(commandInput[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(rubiksMatrix, rowColIndex, steps % rubiksMatrix.GetLength(0));
                        break;
                    case "down":
                        MoveDown(rubiksMatrix, rowColIndex, steps % rubiksMatrix.GetLength(0));
                        break;
                    case "left":
                        MoveLeft(rubiksMatrix, rowColIndex, steps % rubiksMatrix.GetLength(1));
                        break;
                    case "right":
                        MoveRight(rubiksMatrix, rowColIndex, steps % rubiksMatrix.GetLength(1));
                        break;
                }
            }

            PrintResult(rubiksMatrix);
        }

        private static void MoveRight(int[,] rubiksMatrix, int row, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int lastElement = rubiksMatrix[row, rubiksMatrix.GetLength(1) - 1];
                for (int col = rubiksMatrix.GetLength(1) - 1; col > 0; col--)
                {
                    rubiksMatrix[row, col] = rubiksMatrix[row, col - 1];
                }

                rubiksMatrix[row, 0] = lastElement;
            }
        }

        private static void MoveLeft(int[,] rubiksMatrix, int row, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int firstElement = rubiksMatrix[row, 0];
                for (int col = 0; col < rubiksMatrix.GetLength(1) - 1; col++)
                {
                    rubiksMatrix[row, col] = rubiksMatrix[row, col + 1];
                }

                rubiksMatrix[row, rubiksMatrix.GetLength(1) - 1] = firstElement;
            }
        }

        private static void MoveUp(int[,] rubiksMatrix, int col, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int firstElement = rubiksMatrix[0, col];
                for (int row = 0; row < rubiksMatrix.GetLength(0) - 1; row++)
                {
                    rubiksMatrix[row, col] = rubiksMatrix[row + 1, col];
                }

                rubiksMatrix[rubiksMatrix.GetLength(0) - 1, col] = firstElement;
            }
        }

        private static void MoveDown(int[,] rubiksMatrix, int col, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                int lastElement = rubiksMatrix[rubiksMatrix.GetLength(0) - 1, col];
                for (int row = rubiksMatrix.GetLength(0) - 1; row > 0; row--)
                {
                    rubiksMatrix[row, col] = rubiksMatrix[row - 1, col];
                }

                rubiksMatrix[0, col] = lastElement;
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            int counter = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = counter++;
                }
            }
        }

        private static void PrintResult(int[,] matrix)
        {
            int counter = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == counter) 
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearange(matrix, row, col, counter);
                        counter++;
                    }
                }
                
            }
        }

        private static void Rearange(int[,] matrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < matrix.GetLength(0); targetRow++)
            {
                for (int targetCol = 0; targetCol < matrix.GetLength(1); targetCol++)
                {
                    if (matrix[targetRow, targetCol] == counter)
                    {
                        matrix[targetRow, targetCol] = matrix[row, col];
                        matrix[row, col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                        return;
                    }
                }
            }
        }
    }
}
