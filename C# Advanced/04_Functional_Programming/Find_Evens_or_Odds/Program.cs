using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            List<int> numbers = new List<int>();

            for (int i = boundaries[0]; i <= boundaries[1]; i++)
            {
                numbers.Add(i);
            }
            string command = Console.ReadLine();

            Func<int, bool> predicate;

            switch (command)
            {
                case "even":
                    predicate = x => x % 2 == 0;
                    break;
                case "odd":
                    predicate = x => x % 2 != 0;
                    break;
                default:
                    predicate = null;
                    break;
            }
            Console.WriteLine(string.Join(" ", numbers.Where(predicate)));
        }
    }
}
