using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            Func<int, bool> predicate = CreatePredicate(dividers);

            numbers = numbers.Where(predicate).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static Func<int, bool> CreatePredicate(int[] dividers)
        {
            return num =>
            {
                foreach (var div in dividers)
                {
                    if (num % div != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
