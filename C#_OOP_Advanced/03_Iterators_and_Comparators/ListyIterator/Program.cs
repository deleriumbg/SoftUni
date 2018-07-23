using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] createInput = Console.ReadLine().Split();
        var collection = createInput.Length == 1 ? new ListyIterator<string>(null) : new ListyIterator<string>(createInput.Skip(1).ToList());

        string inputCommand = Console.ReadLine();
        while (inputCommand != "END")
        {
            switch (inputCommand)
            {
                case "Move":
                    Console.WriteLine(collection.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(collection.HasNext());
                    break;
                case "Print":
                    try
                    {
                        collection.Print();
                    }
                    catch (ArgumentException argEx)
                    {
                        Console.WriteLine(argEx.Message);
                    }
                    break;
            }
            inputCommand = Console.ReadLine();
        }
    }
}
