using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split(' ').ToList();
            string input = Console.ReadLine();

            while (input != "3:1")
            {
                string[] commandArgs = input.Split(' ');
                string command = commandArgs[0];
                switch (command)
                {
                    case "merge":
                        int startIndex = int.Parse(commandArgs[1]);
                        int endIndex = int.Parse(commandArgs[2]);
                        startIndex = ValidateIndex(startIndex, data.Count - 1);
                        endIndex = ValidateIndex(endIndex, data.Count - 1);
                        Merge(startIndex, endIndex, data);
                        break;
                    case "divide":
                        int index = int.Parse(commandArgs[1]);
                        int partitions = int.Parse(commandArgs[2]);
                        Divide(index, partitions, data);
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", data));
        }

        private static void Divide(int index, int partitions, List<string> data)
        {
            // The index in the divide command will ALWAYS be INSIDE the array.
            string elementToDivide = data[index];
            int partLength = elementToDivide.Length / partitions;
            List<string> dividedElements = new List<string>();

            while (elementToDivide.Length >= partLength)
            {
                dividedElements.Add(elementToDivide.Substring(0, partLength));
                elementToDivide = elementToDivide.Substring(partLength);
            }

            if (elementToDivide.Length > 0)
            {
                dividedElements.Add(elementToDivide);
            }

            if (dividedElements.Count > partitions)
            {
                string concatLastTwoElements = dividedElements[dividedElements.Count - 2] + dividedElements[dividedElements.Count - 1];
                dividedElements.RemoveRange(dividedElements.Count - 2, 2);
                dividedElements.Add(concatLastTwoElements);
            }
            data.RemoveAt(index);
            data.InsertRange(index, dividedElements);
        }

        private static int ValidateIndex(int index, int maxIndex)
        {
            if (index < 0)
            {
                index = 0;
            }
            else if (index > maxIndex)
            {
                index = maxIndex;
            }
            return index;
        }

        private static void Merge(int startIndex, int endIndex, List<string> data)
        {
            StringBuilder concat = new StringBuilder();
            for (int i = startIndex; i <= endIndex; i++)
            {
                concat.Append(data[i]);
            }

            string mergedElements = concat.ToString();
            data.RemoveRange(startIndex, endIndex - startIndex + 1);
            data.Insert(startIndex, mergedElements);
        } 
    }
}
