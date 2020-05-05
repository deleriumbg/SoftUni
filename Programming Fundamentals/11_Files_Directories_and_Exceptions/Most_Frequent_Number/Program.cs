using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] text = File.ReadAllLines("Input.txt");
            File.Delete("Output.txt");
            for (int current = 0; current < text.Length; current++)
            {
                int[] input = text[current].Split(' ').Select(int.Parse).ToArray();
                int result = 0;
                int totalOcurrencies = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    int currentNumber = input[i];
                    int currentOccurancies = 0;
                    for (int j = i; j < input.Length; j++)
                    {
                        if (currentNumber == input[j])
                        {
                            currentOccurancies++;
                            if (currentOccurancies > totalOcurrencies)
                            {
                                totalOcurrencies = currentOccurancies;
                                result = input[i];
                            }
                        }
                    }
                }
                File.AppendAllText("Output.txt", result.ToString() + Environment.NewLine);
            }
        }
    }
}
