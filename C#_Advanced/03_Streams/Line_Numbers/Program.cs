using System.IO;

namespace Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                string line = reader.ReadLine();
                
                using (StreamWriter writer = new StreamWriter("output.txt"))
                {
                    int lineNumber = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {lineNumber}: {line}");
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
