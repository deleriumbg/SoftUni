using System;
using System.Collections.Generic;
using System.Linq;

namespace Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commandArgs = input.Split(' ');
                string command = commandArgs[0];
                switch (command)
                {
                    case "exchange":
                        int exchangeIndex = int.Parse(commandArgs[1]);
                        Exchange(exchangeIndex, data);
                        break;
                    case "max":
                        string maxEvenOrOdd = commandArgs[1];
                        PrintMaxIndex(maxEvenOrOdd, data);
                        break;
                    case "min":
                        string minEvenOrOdd = commandArgs[1];
                        PrintMinIndex(minEvenOrOdd, data);
                        break;
                    case "first":
                        int firstCount = int.Parse(commandArgs[1]);
                        string firstEvenOrOdd = commandArgs[2];
                        PrintFirst(firstCount, firstEvenOrOdd, data);
                        break;
                    case "last":
                        int lastCount = int.Parse(commandArgs[1]);
                        string lastEvenOrOdd = commandArgs[2];
                        PrintLast(lastCount, lastEvenOrOdd, data);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", data)}]");
        }

        private static void PrintLast(int lastCount, string lastEvenOrOdd, List<int> data)
        {
            if (lastCount < 0 || lastCount > data.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> result = new List<int>();

            if (lastEvenOrOdd == "even")
            {
                if (data.All(x => x % 2 != 0))
                {
                    Console.WriteLine("[]");
                    return;
                }
                result = data.Where(x => x % 2 == 0).Reverse().Take(lastCount).ToList();
            }
            else
            {
                if (data.All(x => x % 2 == 0))
                {
                    Console.WriteLine("[]");
                    return;
                }
                result = data.Where(x => x % 2 != 0).Reverse().Take(lastCount).ToList();
            }

            result.Reverse();
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        private static void PrintFirst(int firstCount, string firstEvenOrOdd, List<int> data)
        {
            if (firstCount < 0 || firstCount > data.Count)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            List<int> result = new List<int>();

            if (firstEvenOrOdd == "even")
            {
                if (data.All(x => x % 2 != 0))
                {
                    Console.WriteLine("[]");
                    return;
                }
                result = data.Where(x => x % 2 == 0).Take(firstCount).ToList();
            }
            else
            {
                if (data.All(x => x % 2 == 0))
                {
                    Console.WriteLine("[]");
                    return;
                }
                result = data.Where(x => x % 2 != 0).Take(firstCount).ToList();
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        private static void PrintMinIndex(string minEvenOrOdd, List<int> data)
        {
            int index = 0;
            if (minEvenOrOdd == "even")
            {
                if (data.All(x => x % 2 != 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }
                index = data.LastIndexOf(data.Where(x => x % 2 == 0).Min());
            }
            else
            {
                if (data.All(x => x % 2 == 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }
                index = data.LastIndexOf(data.Where(x => x % 2 != 0).Min());
            }

            Console.WriteLine(index);
        }

        private static void PrintMaxIndex(string evenOrOdd, List<int> data)
        {
            int index = 0;
            if (evenOrOdd == "even")
            {
                if (data.All(x => x % 2 != 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }
                index = data.LastIndexOf(data.Where(x => x % 2 == 0).Max());
            }
            else
            {
                if (data.All(x => x % 2 == 0))
                {
                    Console.WriteLine("No matches");
                    return;
                }
                index = data.LastIndexOf(data.Where(x => x % 2 != 0).Max());
            }

            Console.WriteLine(index);
        }

        private static void Exchange(int exchangeIndex, List<int> data)
        {
            if (exchangeIndex < 0 || exchangeIndex >= data.Count)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            List<int> firstPart = data.Take(exchangeIndex + 1).ToList();
            List<int> secondPart = data.Skip(exchangeIndex + 1).ToList();
            data.Clear();
            data.AddRange(secondPart);
            data.AddRange(firstPart);
        }
    }
}