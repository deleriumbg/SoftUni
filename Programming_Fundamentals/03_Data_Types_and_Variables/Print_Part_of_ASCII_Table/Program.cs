using System;

namespace Print_Part_of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstChar = int.Parse(Console.ReadLine());
            int secondChar = int.Parse(Console.ReadLine());

            for (int i = firstChar; i <= secondChar; i++)
            {
                char output = Convert.ToChar(i);
                Console.Write($"{output} ");
            }
        }
    }
}
