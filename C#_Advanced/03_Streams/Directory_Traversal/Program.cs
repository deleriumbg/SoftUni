using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a directory path:");
            string path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            Dictionary<string, List<FileInfo>> filesDictionary = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }
                filesDictionary[extension].Add(fileInfo);
            }

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string outputPath = $"{desktopPath}\\report.txt";

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (var pair in filesDictionary.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    string extension = pair.Key;
                    var fileInfo = pair.Value;
                    writer.WriteLine(extension);

                    foreach (var info in fileInfo)
                    {
                        writer.WriteLine($"--{info.FullName} - {(double)info.Length / 1024:f3}kb");
                    }
                }
            }
        }
    }
}
