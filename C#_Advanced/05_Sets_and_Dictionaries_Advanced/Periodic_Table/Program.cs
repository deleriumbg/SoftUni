using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicals = new SortedSet<string>();

            int numberOfChemicals = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfChemicals; i++)
            {
                string[] chemicalInput = Console.ReadLine().Split();
                foreach (var chemical in chemicalInput)
                {
                    chemicals.Add(chemical);
                }
            }

            foreach (var chemical in chemicals)
            {
                Console.Write($"{chemical} ");
            }
        }
    }
}
