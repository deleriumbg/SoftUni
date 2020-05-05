using System;

namespace Barcode_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            for (int i = startNum / 1000; i <= endNum / 1000; i++)
            {
                for (int j = (startNum % 1000) / 100; j <= (endNum % 1000) / 100; j++)
                {
                    for (int k = (startNum % 100) / 10; k <= (endNum % 100) / 10; k++)
                    {
                        for (int m = startNum % 10; m <= endNum % 10; m++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && m % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{m} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
