using System;
using System.Linq;

namespace Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int columns = dimensions[1];
            string[,] matrix = new string[rows, columns];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = alphabet[row].ToString() + alphabet[col + row].ToString() + alphabet[row].ToString();
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
