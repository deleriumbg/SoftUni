using System;

namespace Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string hexadecimal = Convert.ToString(input, 16).ToUpper();
            Console.WriteLine(hexadecimal);
            string binary = Convert.ToString(input, 2).ToUpper();
            Console.WriteLine(binary);
        }
    }
}
