using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllLines("Input1.txt");
            string[] file2 = File.ReadAllLines("Input2.txt");
            File.Delete("Output.txt");
            for (int i = 0; i < Math.Min(file1.Length, file2.Length); i++)
            {
                File.AppendAllText("Output.txt", file1[i] + Environment.NewLine);
                File.AppendAllText("Output.txt", file2[i] + Environment.NewLine);               
            }
            for (int i = Math.Min(file1.Length, file2.Length); i < Math.Max(file1.Length, file2.Length); i++)
            {
                try
                {
                    File.AppendAllText("Output.txt", file1[i] + Environment.NewLine);
                }
                catch
                {
                    File.AppendAllText("Output.txt", file2[i] + Environment.NewLine);
                }
            }
        }
    }
}
