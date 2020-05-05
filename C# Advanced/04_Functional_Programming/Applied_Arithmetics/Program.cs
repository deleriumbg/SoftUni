﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(x => x += 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x *= 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => x -= 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
