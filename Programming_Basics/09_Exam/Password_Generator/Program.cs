using System;
using System.Collections.Generic;

namespace Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine().ToUpper());
            char c = char.Parse(Console.ReadLine().ToLower());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 1; i <= a; i++)
            {
                for (char j = 'A'; j <= b; j++)
                {
                    for (char k = 'a'; k <= c; k++)
                    {
                        for (int l = 1; l <= d; l++)
                        {
                            for (int m = 1; m <= e; m++)
                            {
                                for (int n = 1; n <= f; n++)
                                {
                                    counter++;
                                    if (counter == N)
                                    {
                                        Console.WriteLine($"{i}{j}{k}{l}{m}{n}");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("No password on this position");
        }
    }
}
