using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Radioactive_Bunnies
{
    class Program
    {
        private static int playerRow;
        private static int playerCol;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            char[][] field = new char[rows][];

            for (int row = 0; row < field.Length; row++)
            {
                string inputRow = Console.ReadLine();
                field[row] = new char[columns];

                for (int col = 0; col < field[row].Length; col++)
                {
                    field[row][col] = inputRow[col];
                    if (field[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string directions = Console.ReadLine();
            for (int i = 0; i < directions.Length; i++)
            {
                char currentDirection = directions[i];

                switch (currentDirection)
                {
                    case 'U':
                        Move(-1, 0);
                        break;
                    case 'D':
                        Move(1, 0);
                        break;
                    case 'L':
                        Move(0, -1);
                        break;
                    case 'R':
                        Move(0, 1);
                        break;
                }
            }

            PrintField(field);
        }

        private static void Move(int newRow, int newCol)
        {
            throw new NotImplementedException();
        }

        private static void PrintField(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
