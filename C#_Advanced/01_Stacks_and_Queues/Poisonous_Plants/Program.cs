using System;
using System.Collections.Generic;
using System.Linq;

namespace Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int plants = int.Parse(Console.ReadLine());
            int[] pesticideAmount = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] days = new int[plants];
            var indexes = new Stack<int>();
            indexes.Push(0);

            for (int i = 1; i < plants; i++)
            {
                int maxDays = 0;

                while (indexes.Count > 0 && pesticideAmount[indexes.Peek()] >= pesticideAmount[i])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indexes.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}
