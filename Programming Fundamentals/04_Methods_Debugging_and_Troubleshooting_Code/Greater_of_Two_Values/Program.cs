using System;

namespace Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int firstInt = int.Parse(Console.ReadLine());
                    int secondInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstInt, secondInt));
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    Console.WriteLine(GetMax(firstString, secondString));
                    break;
            }
        }

        static int GetMax(int input1, int input2)
        {
            if (input1 >= input2)
            {
                return input1;
            }
            else
            {
                return input2;
            }
        }

        static char GetMax(char input1, char input2)
        {
            if (input1 >= input2)
            {
                return input1;
            }
            else
            {
                return input2;
            }
        }

        static string GetMax(string input1, string input2)
        {
            if (input1.CompareTo(input2) >= 0)
            {
                return input1;
            }
            else
            {
                return input2;
            }
        }
    }
}
