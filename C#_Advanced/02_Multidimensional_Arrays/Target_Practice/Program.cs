using System;
using System.Collections.Generic;
using System.Linq;

namespace Target_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            string snake = Console.ReadLine();
            char[][] matrix = new char[rows][];

            FillMatrix(matrix, columns, snake);
            int[] target = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Shoot(matrix, target);
            Collapse(matrix);
            PrintMatrix(matrix);
        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> elements = new Queue<char>();

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int emptySpaces = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        emptySpaces++;
                    }
                }

                for (int row = 0; row < emptySpaces; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = emptySpaces; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] matrix, int[] target)
        {
            int impactRow = target[0];
            int impactCol = target[1];
            int radius = target[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isInside = Math.Pow((impactRow - row), 2) + Math.Pow((impactCol - col), 2) <=
                                    Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void FillMatrix(char[][] matrix, int columns, string snake)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[columns];
                
                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = snake[counter++];
                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (counter > snake.Length - 1)
                        {
                            counter = 0;
                        }
                        matrix[row][col] = snake[counter++];
                    }

                    isLeft = true;
                }
            }
        }
    }
}
