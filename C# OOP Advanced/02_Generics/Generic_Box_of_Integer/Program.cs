using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfStrings = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfStrings; i++)
        {
            int input = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>(input);
            Console.WriteLine(box);
        }
    }
}
