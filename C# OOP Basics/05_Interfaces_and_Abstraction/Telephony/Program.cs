using System;

class Program
{
    static void Main(string[] args)
    {
        string[] phoneNumbers = Console.ReadLine().Split();
        string[] websites = Console.ReadLine().Split();
        Smartphone smartphone = new Smartphone();

        foreach (var number in phoneNumbers)
        {
            try
            {
                Console.WriteLine(smartphone.Call(number));
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        foreach (var site in websites)
        {
            try
            {
                Console.WriteLine(smartphone.Browse(site));
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}
