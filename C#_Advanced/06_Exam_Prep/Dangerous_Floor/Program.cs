using System;
using System.Linq;

namespace Dangerous_Floor
{
    class Program
    {
        private const int BoardSize = 8;
        private static char[][] board;
        private static int pieceRow;
        private static int pieceCol;
        private static int targetRow;
        private static int targetCol;

        static void Main(string[] args)
        {
            board = new char[8][];

            for (int row = 0; row < BoardSize; row++)
            {
                board[row] = Console.ReadLine().Split(',').Select(char.Parse).ToArray();
            }

            string moveCommand = Console.ReadLine();

            while (moveCommand != "END")
            {
                char typeOfPiece = moveCommand[0];
                pieceRow = int.Parse(moveCommand[1].ToString());
                pieceCol = int.Parse(moveCommand[2].ToString());
                targetRow = int.Parse(moveCommand[4].ToString());
                targetCol = int.Parse(moveCommand[5].ToString());

                if (board[pieceRow][pieceCol] != typeOfPiece)
                {
                    Console.WriteLine("There is no such a piece!");
                    moveCommand = Console.ReadLine();
                    continue;
                }

                bool isValidMove = CheckForValidMove(typeOfPiece);
                if (!isValidMove)
                {
                    Console.WriteLine("Invalid move!");
                    moveCommand = Console.ReadLine();
                    continue;
                }

                if (IsOutside())
                {
                    Console.WriteLine("Move go out of board!");
                    moveCommand = Console.ReadLine();
                    continue;
                }

                board[pieceRow][pieceCol] = 'x';
                board[targetRow][targetCol] = typeOfPiece;
                moveCommand = Console.ReadLine();
            }
        }

        private static bool IsOutside()
        {
            return targetRow < 0 | targetRow >= BoardSize || targetCol < 0 || targetCol >= BoardSize;
        }

        private static bool CheckForValidMove(char typeOfPiece)
        {
            switch (typeOfPiece)
            {
                case 'K':
                    return ValidKingMove();
                case 'R':
                    return ValidRookMove();
                case 'B':
                    return ValidBishopMove();
                case 'Q':
                    return ValidRookMove() || ValidBishopMove();
                case 'P':
                    return ValidPawnMove();
                default:
                    throw new ArgumentException("Invalid type of piece!");
            }
        }

        private static bool ValidKingMove()
        {
            bool validRow = Math.Abs(pieceRow - targetRow) == 0 || Math.Abs(pieceRow - targetRow) == 1;
            bool validColumn = Math.Abs(pieceCol - targetCol) == 0 || Math.Abs(pieceCol - targetCol) == 1;
            return validRow && validColumn;
        }

        private static bool ValidBishopMove()
        {
            return Math.Abs(pieceRow - targetRow) == Math.Abs(pieceCol - targetCol);
        }

        private static bool ValidRookMove()
        {
            return pieceRow == targetRow || pieceCol == targetCol;
        }

        private static bool ValidPawnMove()
        {
            return pieceCol == targetCol && pieceRow - 1 == targetRow;
        }
    }
}
