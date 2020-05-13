using System;
using System.Linq;

namespace Sort_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Console.WriteLine(string.Join(" ", words.OrderBy(x => x)));
        }
    }
}
