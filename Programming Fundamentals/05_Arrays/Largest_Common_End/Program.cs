using System;

namespace Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            int counterLeft = 0;
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] == arr2[i])
                {
                    counterLeft++;
                }
                else
                {
                    break;
                }
            }
            int counterRight = 0;
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[arr1.Length - 1 - i] == arr2[arr2.Length -1 - i])
                {
                    counterRight++;
                }
                else
                {
                    break;
                }
            }
            int counterMax = Math.Max(counterLeft, counterRight);
            Console.WriteLine(counterMax);
        }
    }
}
