using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long rowsAndColumns = long.Parse(Console.ReadLine());
            long[][] triangle = new long[rowsAndColumns][];
            for (int currentRow = 0; currentRow < rowsAndColumns; currentRow++)
            {
                triangle[currentRow] = new long[currentRow + 1];
                triangle[currentRow][0] = 1;
                triangle[currentRow][currentRow] = 1;
                if (currentRow >= 2)
                {
                    for (int widthIndex = 1; widthIndex < currentRow; widthIndex++)
                    {
                        triangle[currentRow][widthIndex] = triangle[currentRow - 1][widthIndex - 1] + triangle[currentRow - 1][widthIndex];
                    }
                }
            }

            for (int row = 0; row < triangle.Length; row++)
            {
                for (int col = 0; col < triangle[row].Length; col++)
                {
                    Console.Write(triangle[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
