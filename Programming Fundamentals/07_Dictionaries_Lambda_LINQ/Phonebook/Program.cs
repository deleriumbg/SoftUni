using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            while (input[0] != "END")
            {
                if (input[0] == "A")
                {
                    if (phonebook.ContainsKey(input[1]) == false)
                    {
                        phonebook.Add(input[1], input[2]);
                    }
                    else
                    {
                        phonebook[input[1]] = input[2];
                    }
                }
                else if (input[0] == "S")
                {
                    if (phonebook.ContainsKey(input[1]) == false)
                    {
                        Console.WriteLine($"Contact {input[1]} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                    }
                }
                input = Console.ReadLine().Split(' ').ToArray();
            }
        }
    }
}
