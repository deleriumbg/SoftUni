using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> upercaseChecker = x => x[0] == x.ToUpper()[0];
            input
                .Where(upercaseChecker)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
