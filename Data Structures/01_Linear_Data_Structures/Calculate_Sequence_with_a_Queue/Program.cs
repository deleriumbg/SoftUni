using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculate_Sequence_with_a_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var queue = new Queue<long>();
            var elements = new List<long>();
            elements.Add(n);
            int counter = 1;

            while (counter <= 50)
            {
                queue.Enqueue(n + 1);
                elements.Add(n + 1);
                queue.Enqueue(2 * n + 1);
                elements.Add(2 * n + 1);
                queue.Enqueue(n + 2);
                elements.Add(n + 2);
                n = queue.Dequeue();
                counter += 3;
            }
            var result = elements.Take(50);
            Console.WriteLine(string.Join(", ", result.ToArray()));
        }
    }
}
