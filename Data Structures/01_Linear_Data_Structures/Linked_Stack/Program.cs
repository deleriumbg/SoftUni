using System;

namespace Linked_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedStack = new LinkedStack<int>();

            for (int i = 0; i < 10; i++)
            {
                linkedStack.Push(i);
            }

            foreach (var item in linkedStack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Count: {linkedStack.Count}");
            Console.WriteLine($"Top: {linkedStack.Pop()}");
            Console.WriteLine("============");

            Console.WriteLine(string.Join(", ", linkedStack.ToArray()));
        }
    }
}
