using System;
using System.IO;

namespace Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Directory.GetFiles("TestFolder");
            File.Delete("Output.txt");
            long size = 0;
            foreach (var file in songs)
            {
                long length = new FileInfo(file).Length;
                size += length;
            }
            double result = size / 1024.0 / 1024.0;
            File.WriteAllText("Output.txt", result.ToString());
        }
    }
}
