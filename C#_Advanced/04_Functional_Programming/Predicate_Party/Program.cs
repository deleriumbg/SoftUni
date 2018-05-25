using System;

namespace Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ');
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commandArgs = command.Split(' ');
                switch (commandArgs[0])
                {
                    case "Remove":

                        break;
                    case "Double":
                        break;
                }
            }
        }
    }
}
