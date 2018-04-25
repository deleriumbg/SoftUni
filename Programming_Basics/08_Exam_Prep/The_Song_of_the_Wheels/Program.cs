using System;
using System.Collections.Generic;

namespace The_Song_of_the_Wheels
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlNumber = int.Parse(Console.ReadLine());
            List<string> result = new List<string>();
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int m = 1; m <= 9; m++)
                        {
                            if (controlNumber == i * j + k * m && i < j && k > m)
                            {
                                result.Add($"{i}{j}{k}{m}");
                                Console.Write($"{i}{j}{k}{m} ");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            try
            {
                Console.WriteLine($"Password: {result[3]}");
            }
            catch 
            {
                Console.WriteLine("No!");
            }
        }
    }
}
