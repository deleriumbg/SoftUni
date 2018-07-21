using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<string> items = new List<string>();
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            string input = Console.ReadLine();
            items.Add(input);
        }

        Box<string> box = new Box<string>(items);
        int[] swapInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstIndex = swapInfo[0];
        int secondIndex = swapInfo[1];

        box.Swap(firstIndex, secondIndex);
        Console.WriteLine(box);
    }
}
