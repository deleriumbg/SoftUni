using System;

namespace Strings_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = "Hello";
            string second = "World";
            object third = first + ' ' + second;
            string result = (string)third;
            Console.WriteLine(result);
        }
    }
}
