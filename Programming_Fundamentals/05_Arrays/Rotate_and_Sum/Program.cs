using System;
using System.Linq;

namespace Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] sum = new int[arr.Length];

            for (int i = 0; i < rotations; i++)
            {
                arr = Rotate(arr);
                for (int j = 0; j < arr.Length; j++)
                {
                    sum[j] += arr[j];
                }
            }
            Console.WriteLine(string.Join(" ", sum));
        }

        static int[] Rotate(int[] arr)
        {
            int[] rotated = new int[arr.Length];
            rotated[0] = arr[arr.Length - 1];
            for (int i = 1; i < rotated.Length; i++)
            {
                rotated[i] = arr[i - 1];
            }
            return rotated;
        }
    }
}
