using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int counter = 1;
            int counterMax = 0;
            int number = 0;

            for (int position = 1; position < input.Length; position++)
            {
                if (input[position] == input[position - 1])
                {
                    counter++;
                    if (counter > counterMax)
                    {
                        counterMax = counter;
                        number = input[position];
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            for (int i = 0; i < counterMax; i++)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}
