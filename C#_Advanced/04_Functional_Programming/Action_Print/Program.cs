using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            Action<string> output = x => Console.WriteLine(x);
            input.ForEach(output);
        }
    }
}
