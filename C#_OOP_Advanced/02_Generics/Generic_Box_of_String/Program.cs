using System;

class Program
{
    static void Main(string[] args)
    {
        int numberOfStrings = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfStrings; i++)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}