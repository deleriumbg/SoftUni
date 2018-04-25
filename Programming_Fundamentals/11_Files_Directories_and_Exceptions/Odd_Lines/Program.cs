using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("Input.txt");
            File.Delete("Output.txt");
            List<string> result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 != 0)
                {
                    result.Add(input[i]);
                }
            }
            File.AppendAllLines("Output.txt", result);
        }
    }
}
