using System;

namespace Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int first = input % 10;
            input /= 10;
            int second = input % 10;
            int third = input / 10;

            for (int i = 1; i <= first; i++)
            {
                for (int j = 1; j <= second; j++)
                {
                    for (int k = 1; k <= third; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                    }
                }
            }
        }
    }
}
