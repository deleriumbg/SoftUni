using System;
using System.IO;

namespace Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = File.ReadAllText("Input.txt").ToCharArray();
            File.Delete("Output.txt");
            for (int i = 0; i < input.Length; i++)
            {
                string result = $"{input[i]} -> {input[i] - 'a'}";
                File.AppendAllText("Output.txt", result + Environment.NewLine);
            }
        }
    }
}
