using System;
using System.Collections.Generic;
using System.Linq;

namespace Files
{
    class File
    {
        public string Root { get; set; }
        public string FullName { get; set; }
        public long Size { get; set; }

        public File(string root, string fullName, long size)
        {
            Root = root;
            FullName = fullName;
            Size = size;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfFiles = int.Parse(Console.ReadLine());
            List<File> files = new List<File>();

            for (int i = 0; i < numberOfFiles; i++)
            {
                string[] fullPath = Console.ReadLine().Split(new [] { '\\', ';' },StringSplitOptions.RemoveEmptyEntries);
                string rootDirectory = fullPath[0];
                string fullFileName = fullPath[fullPath.Length - 2];
                long fileSize = long.Parse(fullPath[fullPath.Length - 1]);

                File file = new File(rootDirectory, fullFileName, fileSize);
                if (!files.Any(x => x.Root == rootDirectory && x.FullName == fullFileName))
                {
                    files.Add(file);
                }
                else
                {
                    File existingFile = files.First(x => x.Root == rootDirectory && x.FullName == fullFileName);
                    existingFile.Size = fileSize;
                }
            }

            string[] printCommand = Console.ReadLine().Split(new [] { " in " },StringSplitOptions.RemoveEmptyEntries);
            string extension = printCommand[0];
            string folder = printCommand[1];

            //Print all file names with a given extension that are present in a given root directory sorted by their file size in descending order.
            //If two files have same size, order them by alphabetical order.
            if (!files.Any(x => x.Root == folder && x.FullName.EndsWith(extension)))
            {
                Console.WriteLine("No");
                return;
            }

            var filtered = files.Where(x => x.Root == folder && x.FullName.EndsWith(extension));
            foreach (var file in filtered.OrderByDescending(x => x.Size).ThenBy(x => x.FullName))  
            {
                Console.WriteLine($"{file.FullName} - {file.Size} KB ");
            }
        }
    }
}
