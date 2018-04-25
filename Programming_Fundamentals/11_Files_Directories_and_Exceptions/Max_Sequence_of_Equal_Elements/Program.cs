using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("Input.txt");
            File.Delete("Output.txt");
            for (int row = 0; row < text.Length; row++)
            {
                int[] input = text[row].Split(' ').Select(int.Parse).ToArray();
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

                StringBuilder result = new StringBuilder();
                for (int i = 0; i < counterMax; i++)
                {
                    result.Append($"{number} ");
                }
                File.AppendAllText("Output.txt", result.ToString() + Environment.NewLine);
            }
        }
    }
}
