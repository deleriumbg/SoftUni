using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Zipping_Sliced_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = "sliceMe.mp4";
            string destinationDirectory = "./";
            int parts = 5;

            Zip(sourceFile, destinationDirectory, parts);

            List<string> files = new List<string>
            {
                "Part-0.mp4.gz",
                "Part-1.mp4.gz",
                "Part-2.mp4.gz",
                "Part-3.mp4.gz",
                "Part-4.mp4.gz"
            };

            Assemble(files, destinationDirectory);
        }

        private static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long partSize = (long)Math.Ceiling((double)reader.Length / parts);
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));

                for (int i = 0; i < parts; i++)
                {
                    long currentPartSize = 0;
                    string partName = $"{destinationDirectory}\\Part-{i}{extension}.gz";

                    using (GZipStream compress = new GZipStream(new FileStream(partName, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);
                            compress.Write(buffer, 0, readBytes);
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
            string extension = files[0].Substring(files[0].IndexOf('.'), 4);
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
