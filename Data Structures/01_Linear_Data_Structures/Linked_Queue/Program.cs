using System;

class Program
{
    static void Main(string[] args)
    {
        var queue = new LinkedQueue<int>();
        for (int i = 1; i <= 5; i++)
        {
            queue.Enqueue(i);
        }

        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine($"Count {queue.Count}");
        Console.WriteLine("==============");

        for (int i = 1; i <= 7; i++)
        {
            try
            {
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Error {e.Message}");
            }

            Console.WriteLine(string.Join(", ", queue.ToArray()));
        }
    }
}
