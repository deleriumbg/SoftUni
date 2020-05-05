using System;
using System.IO;
using System.Text;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("Input.txt");
            File.Delete("Output.txt");
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int index = i + 1;
                result.AppendLine($"{index}. {input[i]}");
            }
            File.WriteAllText("Output.txt", result.ToString());
        }
    }
}
