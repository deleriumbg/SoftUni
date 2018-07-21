using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> items = new List<int>();
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            int input = int.Parse(Console.ReadLine());
            items.Add(input);
        }

        Box<int> box = new Box<int>(items);
        int[] swapInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstIndex = swapInfo[0];
        int secondIndex = swapInfo[1];

        box.Swap(firstIndex, secondIndex);
        Console.WriteLine(box);
    }
}
