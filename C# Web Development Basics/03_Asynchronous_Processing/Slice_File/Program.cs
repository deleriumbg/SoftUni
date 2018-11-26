using System;
using System.IO;
using System.Threading.Tasks;

namespace Slice_File
{
    class Program
    {
        private const int BufferLength = 4096;

        static void Main(string[] args)
        {
            string videoPath = Console.ReadLine();
            string destination = Console.ReadLine();
            int pieces = int.Parse(Console.ReadLine());

            SliceAsync(videoPath, destination, pieces);

            Console.WriteLine("Anything else?");
            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void SliceAsync(string sourceFile, string destinationPath, int parts)
        {
            Task.Run(() =>
            {
                Slice(sourceFile, destinationPath, parts);
            });
        }

        private static void Slice(string sourceFile, string destinationPath, int parts)
        {
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            using (FileStream source = new FileStream(sourceFile, FileMode.Open))
            {
                FileInfo fileInfo = new FileInfo(sourceFile);
                long partLength = (source.Length / parts) + 1;
                long currentByte = 0;

                for (int currentPart = 1; currentPart <= parts; currentPart++)
                {
                    string filePath = $"{destinationPath}/Part-{currentPart}{fileInfo.Extension}";

                    using (FileStream destination = new FileStream(filePath, FileMode.Create))
                    {
                        byte[] buffer = new byte[BufferLength];
                        while (currentByte <= currentPart * partLength)
                        {
                            int readBytesCount = source.Read(buffer, 0, buffer.Length);
                            if (readBytesCount == 0)
                            {
                                break;
                            }
                            destination.Write(buffer, 0, readBytesCount);
                            currentByte += readBytesCount;
                        }
                    }
                }

                Console.WriteLine("Slice complete");
            }
        }
    }
}
