using System;
using System.Collections.Generic;
using System.Linq;

namespace Sequence_N_M
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int start = input[0];
            int end = input[1];

            if (start > end)
            {
                return;
            }

            FindSequence(start, end);
        }

        private static void FindSequence(int start, int end)
        {
            var queue = new Queue<Item>();
            queue.Enqueue(new Item(start, null));

            while (queue.Any())
            {
                var currentItem = queue.Dequeue();

                if (currentItem.Value == end)
                {
                    PrintSolution(currentItem);
                    break;
                }

                if (currentItem.Value < end)
                {
                    queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
                    queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
                    queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
                }
            }
        }

        private static void PrintSolution(Item currentItem)
        {
            var solution = new Stack<int>();
            while (currentItem != null)
            {
                solution.Push(currentItem.Value);
                currentItem = currentItem.Previous;
            }

            Console.WriteLine(string.Join(" -> ", solution));
        }

        private class Item
        {
            public Item(int value, Item previous)
            {
                this.Value = value;
                this.Previous = previous;
            }

            public int Value { get; }

            public Item Previous { get; }
        }
    }
}
