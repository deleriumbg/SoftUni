using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            string commandInput = Console.ReadLine();

            while (commandInput != "end")
            {
                string[] commandArgs = commandInput.Split(' ');
                string command = commandArgs[0];

                switch (command)
                {
                    case "swap":
                        int swap1 = int.Parse(commandArgs[1]);
                        int swap2 = int.Parse(commandArgs[2]);
                        if (swap1 >= 0 && swap1 < numbers.Count && swap2 >= 0 && swap2 < numbers.Count)
                        {
                            long temp = numbers[swap1];
                            numbers[swap1] = numbers[swap2];
                            numbers[swap2] = temp;
                        }
                        break;
                    case "multiply":
                        int multiply1 = int.Parse(commandArgs[1]);
                        int multiply2 = int.Parse(commandArgs[2]);
                        if (multiply1 >= 0 && multiply1 < numbers.Count && multiply2 >= 0 && multiply2 < numbers.Count)
                        {
                            numbers[multiply1] *= numbers[multiply2];
                        }
                        break;
                    case "decrease":
                        numbers = numbers.Select(x => x - 1).ToList();
                        break;
                }
                commandInput = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
