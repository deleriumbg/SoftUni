using System;

namespace Slot_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            for (int i = 0; i < 3; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                int number = int.Parse(Console.ReadLine());
                int sum = number + letter;
                char output = (char)sum;
                result += output;
            }
            Console.WriteLine(result);
            if (result == "@@@")
            {
                Console.WriteLine("!!! YOU LOSE EVERYTHING !!!");
            }
            else if (result == "777")
            {
                Console.WriteLine("*** JACKPOT ***");
            }
        }
    }
}
