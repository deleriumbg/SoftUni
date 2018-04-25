using System;
using System.Collections.Generic;
using System.Linq;

namespace Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> commands = Console.ReadLine().Split(' ').ToList();

            while (commands[0] != "Even" && commands[0] != "Odd")
            {
                if (commands[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(commands[1]));
                }
                else if (commands[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }
                commands = Console.ReadLine().Split(' ').ToList();
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (commands[0] == "Even")
                {
                    numbers.RemoveAll(x => x % 2 == 1);
                }
                else if (commands[0] == "Odd")
                {
                    numbers.RemoveAll(x => x % 2 == 0);
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
