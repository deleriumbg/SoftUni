using System;

namespace Rhombus_of_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            int rhombusSize = int.Parse(Console.ReadLine());

            for (int currentRow = 1; currentRow <= rhombusSize; currentRow++)
            {
                PrintRow(rhombusSize, currentRow);
            }

            for (int currentRow = rhombusSize - 1; currentRow >= 0; currentRow--)
            {
                PrintRow(rhombusSize, currentRow);
            }
            
        }

        private static void PrintRow(int rhombusSize, int currentRow)
        {
            Console.Write($@"{new string(' ', rhombusSize - currentRow)}");
            for (int i = 0; i < currentRow; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
