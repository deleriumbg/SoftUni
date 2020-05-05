using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Command_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> dataInput = Console.ReadLine().Split(' ').ToList();
            string commandInput = Console.ReadLine();

            while (commandInput != "end")
            {
                string[] commandArgs = commandInput.Split(' ');
                string command = commandArgs[0];
                switch (command)
                {
                    case "reverse":
                        int reverseStartIndex = int.Parse(commandArgs[2]);
                        int reverseCount = int.Parse(commandArgs[4]);
                        ReverseElements(reverseStartIndex, reverseCount, dataInput);
                        break;
                    case "sort":
                        int sortStartIndex = int.Parse(commandArgs[2]);
                        int sortCount = int.Parse(commandArgs[4]);
                        SortElements(sortStartIndex, sortCount, dataInput);
                        break;
                    case "rollLeft":
                        int rollLeftCount = int.Parse(commandArgs[1]);
                        RollLeft(rollLeftCount, dataInput);
                        break;
                    case "rollRight":
                        int rollRightCount = int.Parse(commandArgs[1]);
                        RollRight(rollRightCount, dataInput);
                        break;
                }
                commandInput = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", dataInput)}]");
        }

        private static void RollRight(int rollRightCount, List<string> dataInput)
        {
            if (rollRightCount < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            rollRightCount = rollRightCount % dataInput.Count;
            List<string> result = dataInput.GetRange(dataInput.Count - rollRightCount, rollRightCount);
            result.AddRange(dataInput.GetRange(0, dataInput.Count - rollRightCount));
            dataInput.Clear();
            dataInput.AddRange(result);
        }

        private static void RollLeft(int rollLeftCount, List<string> dataInput)
        {
            if (rollLeftCount < 0)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }
            rollLeftCount = rollLeftCount % dataInput.Count;
            Queue<string> queue = new Queue<string>(dataInput);
            for (int i = 0; i < rollLeftCount; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            dataInput.Clear();
            dataInput.AddRange(queue);
        }

        private static void SortElements(int sortStartIndex, int sortCount, List<string> dataInput)
        {
            if (sortStartIndex < 0 || sortStartIndex >= dataInput.Count || sortCount < 0 || sortCount > dataInput.Count - sortStartIndex)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            List<string> partToSort = dataInput.Skip(sortStartIndex).Take(sortCount).OrderBy(x => x).ToList();
            dataInput.RemoveRange(sortStartIndex, sortCount);
            dataInput.InsertRange(sortStartIndex, partToSort);
        }

        private static void ReverseElements(int startIndex, int count, List<string> dataInput)
        {
            if (startIndex < 0 || startIndex >= dataInput.Count || count < 0 || count > dataInput.Count - startIndex)
            {
                Console.WriteLine("Invalid input parameters.");
                return;
            }

            List<string> partToReverse = dataInput.Skip(startIndex).Take(count).Reverse().ToList();
            dataInput.RemoveRange(startIndex, count);
            dataInput.InsertRange(startIndex, partToReverse);
        }
    }
}