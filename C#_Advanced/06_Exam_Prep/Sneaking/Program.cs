using System;
using System.Linq;

namespace Sneaking
{
    class Program
    {
        private static char[][] room;
        private static int playerRow;
        private static int playerCol;

        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            room = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
                if (room[row].Contains('S'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(room[row], 'S');
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            foreach (var direction in directions)
            {
                MoveEnemies();

                if (room[playerRow].Contains('b') && Array.IndexOf(room[playerRow], 'b') < playerCol)
                {
                    room[playerRow][playerCol] = 'X';
                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                    PrintRoom();
                    break;
                }
                else if (room[playerRow].Contains('d') && Array.IndexOf(room[playerRow], 'd') > playerCol)
                {
                    room[playerRow][playerCol] = 'X';
                    Console.WriteLine($"Sam died at {playerRow}, {playerCol}");
                    PrintRoom();
                    break;
                }

                MovePlayer(direction);

                if (room[playerRow].Contains('N'))
                {
                    int enemyIndex = Array.IndexOf(room[playerRow], 'N');
                    room[playerRow][enemyIndex] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintRoom();
                    break;
                }
            } 
        }

        private static void MovePlayer(char direction)
        {
            room[playerRow][playerCol] = '.';
            switch (direction)
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'L':
                    playerCol--;
                    break;
                case 'R':
                    playerCol++;
                    break;
                default:
                    break;
            }
            room[playerRow][playerCol] = 'S';
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Contains('d'))
                {
                    int enemyIndex = Array.IndexOf(room[row], 'd');
                    if (enemyIndex == 0)
                    {
                        room[row][0] = 'b';
                    }
                    else
                    {
                        room[row][enemyIndex] = '.';
                        room[row][enemyIndex - 1] = 'd';
                    }
                }
                else if (room[row].Contains('b'))
                {
                    int enemyIndex = Array.IndexOf(room[row], 'b');
                    if (enemyIndex == room[row].Length - 1)
                    {
                        room[row][room[row].Length - 1] = 'd';
                    }
                    else
                    {
                        room[row][enemyIndex] = '.';
                        room[row][enemyIndex + 1] = 'b';
                    }
                }
            }
        }

        private static void PrintRoom()
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
