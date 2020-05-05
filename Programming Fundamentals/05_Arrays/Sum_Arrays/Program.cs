using System;
using System.Linq;

namespace Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int [] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int length1 = arr1.Length;
            int length2 = arr2.Length;
            int lengthResult = Math.Max(length1, length2);
            int [] result = new int [lengthResult];

            for (int position = 0; position < lengthResult; position++)
            {
                result[position] = arr1[position % length1] + arr2[position % length2];
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
