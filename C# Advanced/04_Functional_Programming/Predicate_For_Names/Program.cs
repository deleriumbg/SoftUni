using System;
using System.Linq;

namespace Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ');

            Func<string, bool> filter = x => x.Length <= nameLength;

            names = names.Where(filter).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
