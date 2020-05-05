using System;
using System.Collections.Generic;
using System.Linq;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            Dictionary<int, int> numberOccurencies = new Dictionary<int, int>();

            for (int i = 0; i < numbersCount; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (!numberOccurencies.ContainsKey(currentNumber))
                {
                    numberOccurencies.Add(currentNumber, 0);
                }

                numberOccurencies[currentNumber]++;
            }

            int result = numberOccurencies.FirstOrDefault(x => x.Value % 2 == 0).Key;
            Console.WriteLine(result);
        }
    }
}
