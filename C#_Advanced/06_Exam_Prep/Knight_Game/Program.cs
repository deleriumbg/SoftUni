using System;

namespace Knight_Game
{
    class Program
    {
        private static char[][] board;

        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            board = new char[boardSize][];

            for (int row = 0; row < boardSize; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }

            int totalKnights = 0;

            while (true)
            {
                int maxKnights = 0;
                int maxRow = 0;
                int maxCol = 0;

                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board[row].Length; col++)
                    {
                        int currentKnights = 0;

                        if (board[row][col] == 'K')
                        {
                            if (IsInside(row - 2, col - 1) && board[row - 2][col - 1] == 'K')
                            {
                                currentKnights++;
                            }
                            if (IsInside(row - 2, col + 1) && board[row - 2][col + 1] == 'K')
                            {
                                currentKnights++;
                            }
                            if (IsInside(row - 1, col - 2) && board[row - 1][col - 2] == 'K')
                            {
                                currentKnights++;
                            }
                            if (IsInside(row - 1, col + 2) && board[row - 1][col + 2] == 'K')
                            {
                                currentKnights++;
                            }
                            if (IsInside(row + 1, col - 2) && board[row + 1][col - 2] == 'K')
                            {
                                currentKnights++;
                            }
                            if (IsInside(row + 1, col + 2) && board[row + 1][col + 2] == 'K')
                            {
                                currentKnights++;
                            }
                            if (IsInside(row + 2, col - 1) && board[row + 2][col - 1] == 'K')
                            {
                                currentKnights++;
                            }
                            if (IsInside(row + 2, col + 1) && board[row + 2][col + 1] == 'K')
                            {
                                currentKnights++;
                            }
                        }

                        if (currentKnights > maxKnights)
                        {
                            maxKnights = currentKnights;
                            maxRow = row;
                            maxCol = col;
                        }
                    }
                }

                if (maxKnights > 0)
                {
                    board[maxRow][maxCol] = '0';
                    totalKnights++;
                }
                else
                {
                    Console.WriteLine(totalKnights);
                    break;
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < board.Length && col >= 0 && col < board[row].Length;
        }
    }
}
