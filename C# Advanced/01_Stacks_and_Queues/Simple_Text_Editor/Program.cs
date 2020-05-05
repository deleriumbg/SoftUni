using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOperations = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            stack.Push("");
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < numberOperations; i++)
            {
                string[] operation = Console.ReadLine().Split(' ');
                switch (operation[0])
                {
                    case "1":
                        stack.Push(text.ToString());
                        text.Append(operation[1]);
                        break;
                    case "2":
                        stack.Push(text.ToString());
                        int elementsToErase = int.Parse(operation[1]);
                        text.Remove(text.Length - elementsToErase, elementsToErase);
                        break;
                    case "3":
                        int indexToReturn = int.Parse(operation[1]);
                        Console.WriteLine(text[indexToReturn - 1]);
                        break;
                    case "4":
                        text.Clear();
                        text.Append(stack.Pop());
                        break;
                }
            }
        }
    }
}
