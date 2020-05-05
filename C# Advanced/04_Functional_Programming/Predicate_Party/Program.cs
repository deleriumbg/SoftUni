using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();

            ParseCommands(names);

            if (names.Count > 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }  
        }

        private static void ParseCommands(List<string> names)
        {
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commandArgs = command.Split(' ');

                switch (commandArgs[1])
                {
                    case "StartsWith":
                        CheckCondition(names, commandArgs[0], x => x.StartsWith(commandArgs[2]));
                        break;
                    case "EndsWith":
                        CheckCondition(names, commandArgs[0], x => x.EndsWith(commandArgs[2]));
                        break;
                    case "Length":
                        CheckCondition(names, commandArgs[0], x => x.Length == int.Parse(commandArgs[2]));
                        break;
                    default:
                        break;

                }
                command = Console.ReadLine();
            }
        }

        private static void CheckCondition(List<string> names, string command, Func<string, bool> condition)
        {
            for (int currentName = names.Count - 1; currentName >= 0; currentName--)
            {
                if (condition(names[currentName]))
                {
                    switch (command)
                    {
                        case "Remove":
                            names.RemoveAt(currentName);
                            break;
                        case "Double":
                            names.Add(names[currentName]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
