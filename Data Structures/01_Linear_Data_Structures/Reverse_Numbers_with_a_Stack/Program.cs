using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            var stack = new Stack<int>(input);
            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
