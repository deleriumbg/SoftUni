using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<double> collection = new List<double>();
        int numberOfStrings = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStrings; i++)
        {
            double input = double.Parse(Console.ReadLine());
            collection.Add(input);
        }
        double element = double.Parse(Console.ReadLine());
        Box<double> box = new Box<double>(collection, element);
        Console.WriteLine(box.FindNumberOfGreaterElements(collection, element));
    }
}
