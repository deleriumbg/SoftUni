using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Func<int[], int> minFunc = FindMin;
            int min = minFunc(numbers);
            Console.WriteLine(min);
        }

        private static int FindMin(int[] numbers)
        {
            int min = int.MaxValue;

            foreach (var num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }
    }
}
