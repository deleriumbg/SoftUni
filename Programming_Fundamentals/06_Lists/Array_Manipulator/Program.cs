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
                if (commands[0] == "add")
                {
                    numbers.Insert(int.Parse(commands[1]), int.Parse(commands[2]));
                }
                else if (commands[0] == "addMany")
                {
                    numbers.InsertRange(int.Parse(commands[1]), commands.Skip(2).Select(int.Parse));
                }
                else if (commands[0] == "contains")
                {
                    if (numbers.Contains(int.Parse(commands[1])))
                    {
                        Console.WriteLine(numbers.IndexOf(int.Parse(commands[1])));
                    }
                    else
                    {
                        Console.WriteLine("-1");
                    }
                }
                else if (commands[0] == "remove")
                {
                    numbers.RemoveAt(int.Parse(commands[1]));
                }
                else if (commands[0] == "shift")
                {
                    int shifts = int.Parse(commands[1]) % numbers.Count;
                    List<int> temp = numbers.Skip(shifts).ToList();
                    for (int i = 0; i < shifts; i++)
                    {
                        temp.Add(numbers[i]);
                    }
                    numbers = temp;
                }
                else if (commands[0] == "sumPairs")
                {
                    int cycles = numbers.Count / 2;
                    for (int i = 0; i < cycles; i++)
                    {
                        numbers[i] += numbers[i + 1];
                        numbers.RemoveAt(i + 1);
                    }
                }
                commands = Console.ReadLine().Split(' ').ToList();
            }
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }
    }
}
