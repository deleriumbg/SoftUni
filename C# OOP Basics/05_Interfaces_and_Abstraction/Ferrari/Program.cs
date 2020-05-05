using System;

class Program
{
    static void Main(string[] args)
    {
        string driver = Console.ReadLine();
        Ferrari ferrari = new Ferrari(driver);
        Console.WriteLine(ferrari);
    }
}
