using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
            int index = 0;

            while (index < numbers.Count - 1)
            {
                if (numbers[index] == numbers[index + 1])
                {
                    numbers[index] = numbers[index] + numbers[index + 1];
                    numbers.RemoveAt(index + 1);
                    if (index > 0)
                    {
                        index--;
                    }
                }
                else
                {
                    index++;
                }

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
