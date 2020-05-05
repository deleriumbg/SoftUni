using System;

namespace Blank_Receipt
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader();
            PrintBody();
            PrintFooter();
        }

        static void PrintHeader()
        {
            Console.WriteLine($"CASH RECEIPT\r\n------------------------------");
        }

        static void PrintBody()
        {
            Console.WriteLine($"Charged to____________________\r\nReceived by___________________");
        }

        static void PrintFooter()
        {
            Console.WriteLine($"------------------------------\r\n© SoftUni");
        }
    }
}
