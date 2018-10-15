using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        private static char[][] field;
        private static int minerRow;
        private static int minerCol;
        private static int totalCoal;
        private static int collectedCoal;

        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split();
            field = new char[fieldSize][];

            for (int row = 0; row < fieldSize; row++)
            {
                field[row] = new char[fieldSize];
                char[] rowInput = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < fieldSize; col++)
                {
                    field[row][col] = rowInput[col];
                    if (field[row][col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }

                    if (field[row][col] == 'c')
                    {
                        totalCoal++;
                    }
                }
            }

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                }
            }

            Console.WriteLine($"{totalCoal - collectedCoal} coals left. ({minerRow}, {minerCol})");
        }

        private static void Move(int newRow, int newCol)
        {
            int targetRow = minerRow + newRow;
            int targetCol = minerCol + newCol;

            if (IsInside(targetRow, targetCol))
            {
                if (field[targetRow][targetCol] == 'c')
                {
                    collectedCoal++;
                    field[targetRow][targetCol] = '*';
                    if (collectedCoal == totalCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({targetRow}, {targetCol})");
                        Environment.Exit(0);
                    }
                }

                if (field[targetRow][targetCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({targetRow}, {targetCol})");
                    Environment.Exit(0);
                }

                field[minerRow][minerCol] = '*';
                minerRow = targetRow;
                minerCol = targetCol;
                field[minerRow][minerCol] = 's';
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }

        private static void PrintField()
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
