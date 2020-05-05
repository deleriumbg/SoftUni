using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> commands = Console.ReadLine().Split(' ').ToList();

            while (commands[0] != "print")
            {
                switch (commands[0])
                {
                    case "add":
                        numbers.Insert(int.Parse(commands[1]), int.Parse(commands[2]));
                        break;
                    case "addMany":
                        numbers.InsertRange(int.Parse(commands[1]), commands.Skip(2).Select(int.Parse));
                        break;
                    case "contains":
                        Console.WriteLine(numbers.IndexOf(int.Parse(commands[1])));
                        break;
                    case "remove":
                        numbers.RemoveAt(int.Parse(commands[1]));
                        break;
                    case "shift":
                        int shifts = int.Parse(commands[1]) % numbers.Count;
                        List<int> temp = numbers.Skip(shifts).ToList();
                        for (int i = 0; i < shifts; i++)
                        {
                            temp.Add(numbers[i]);
                        }
                        numbers = temp;
                        break;
                    case "sumPairs":
                        int cycles = numbers.Count / 2;
                        for (int i = 0; i < cycles; i++)
                        {
                            numbers[i] += numbers[i + 1];
                            numbers.RemoveAt(i + 1);
                        }
                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine().Split(' ').ToList();
            }
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }
    }
}
