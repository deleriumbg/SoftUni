using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> collection = new List<string>();
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            string input = Console.ReadLine();
            collection.Add(input);
        }
        string element = Console.ReadLine();
        Box<string> box = new Box<string>(collection, element);
        Console.WriteLine(box.FindNumberOfGreaterElements(collection, element));
    }
}
