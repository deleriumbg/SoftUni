using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Bunnies
{
    class Program
    {
        private static int playerRow;
        private static int playerCol;
        private static char[][] field;
        private static bool playerIsDead;
        private static bool playerIsOutside;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];

            field = new char[rows][];

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
            foreach (var currentDirection in directions)
            {
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

                SpreadBunnies();

                if (playerIsOutside)
                {
                    PrintField();
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }

                if (playerIsDead)
                {
                    PrintField();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void SpreadBunnies()
        {
            Queue<int[]> bunnyIndexes = new Queue<int[]>();

            for (int row = 0; row < field.Length; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'B')
                    {
                        bunnyIndexes.Enqueue(new int[] {row, col});
                    }
                }
            }

            while (bunnyIndexes.Count > 0)
            {
                int[] currentBunnyIndexes = bunnyIndexes.Dequeue();
                int bunnyRow = currentBunnyIndexes[0];
                int bunnyCol = currentBunnyIndexes[1];

                if (IsInside(bunnyRow - 1, bunnyCol))
                {
                    if (IsPlayer(bunnyRow - 1, bunnyCol))
                    {
                        playerIsDead = true;
                    }

                    field[bunnyRow - 1][bunnyCol] = 'B';
                }
                if (IsInside(bunnyRow + 1, bunnyCol))
                {
                    if (IsPlayer(bunnyRow + 1, bunnyCol))
                    {
                        playerIsDead = true;
                    }

                    field[bunnyRow + 1][bunnyCol] = 'B';
                }
                if (IsInside(bunnyRow, bunnyCol - 1))
                {
                    if (IsPlayer(bunnyRow, bunnyCol - 1))
                    {
                        playerIsDead = true;
                    }

                    field[bunnyRow][bunnyCol - 1] = 'B';
                }
                if (IsInside(bunnyRow, bunnyCol + 1))
                {
                    if (IsPlayer(bunnyRow, bunnyCol + 1))
                    {
                        playerIsDead = true;
                    }

                    field[bunnyRow][bunnyCol + 1] = 'B';
                }
            }
        }

        private static void Move(int newRow, int newCol)
        {
            int targetRow = playerRow + newRow;
            int targetCol = playerCol + newCol;

            if (!IsInside(targetRow, targetCol))
            {
                playerIsOutside = true;
                field[playerRow][playerCol] = '.';
            }
            else if (IsBunny(targetRow, targetCol))
            {
                playerIsDead = true;
                playerRow = targetRow;
                playerCol = targetCol;
            }
            else
            {
                field[playerRow][playerCol] = '.';
                playerRow = targetRow;
                playerCol = targetCol;
                field[playerRow][playerCol] = 'P';
            }
        }

        private static bool IsPlayer(int targetRow, int targetCol)
        {
            return field[targetRow][targetCol] == 'P';
        }

        private static bool IsBunny(int targetRow, int targetCol)
        {
            return field[targetRow][targetCol] == 'B';
        }

        private static bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < field.Length && targetCol >= 0 && targetCol < field[targetRow].Length;
        }

        private static void PrintField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
