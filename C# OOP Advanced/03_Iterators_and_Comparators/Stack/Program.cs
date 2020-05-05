using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        CustomStack<string> customStack = new CustomStack<string>();
        string[] input = Console.ReadLine().Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries);
        while (input[0] != "END")
        {
            switch (input[0])
            {
                case "Push":
                    string[] elements = input.Skip(1).ToArray();
                    customStack.Push(elements);
                    break;
                case "Pop":
                    try
                    {
                        customStack.Pop();
                    }
                    catch (ArgumentException argEx)
                    {
                        Console.WriteLine(argEx.Message);
                    }
                    break;
            }
            input = Console.ReadLine().Split();
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
