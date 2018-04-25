using System;
using System.Linq;

namespace Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isFound = false;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (0 <= i && i < j && j < arr.Length)
                    {
                        if (arr.Contains(arr[i] + arr[j]))
                        {
                            Console.WriteLine($"{arr[i]} + {arr[j]} == {arr[i] + arr[j]}");
                            isFound = true;
                        }
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("No");
            }
        }
    }
}
