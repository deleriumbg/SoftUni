using System;
using System.Collections.Generic;
using System.IO;

namespace Slicing_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "sliceMe.mp4";
            string destinationDirectory = "./";
            int parts = 5;

            Slice(sourceFile, destinationDirectory, parts);

            List<string> files = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4"
            };

            Assemble(files, destinationDirectory);
        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long partSize = (long)Math.Ceiling((double)reader.Length / parts);
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));
           
                for (int i = 0; i < parts; i++)
                {
                    long currentPartSize = 0;
                    string partName = $"{destinationDirectory}\\Part-{i}{extension}";

                    using (FileStream writer = new FileStream(partName, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            writer.Write(buffer, 0, readBytes);
                            currentPartSize += buffer.Length;

                            if (currentPartSize >= partSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.'));
            string assembledName = $"{destinationDirectory}\\Assembled{extension}";

            using (FileStream writer = new FileStream(assembledName, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            
                            if (readBytes == 0)
                            {
                                break;
                            }
                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }              
            }
        }
    }
}
