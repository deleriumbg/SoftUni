using System;

namespace Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            int bunkerCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            while (input[0] != "Bunker" && input[1] != "Revision")
            {
                foreach (var entry in input)
                {
                    
                }


                input = Console.ReadLine().Split();
            }
        }
    }
}
