using System;
using System.Linq;

namespace Crypto_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int maxSequence = 0;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int index = 0; index < numbers.Length; index++)
                {
                    int currentIndex = index;
                    int nextIndex = (index + step) % numbers.Length;
                    int currentSequence = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentSequence++;
                        currentIndex = nextIndex;
                        nextIndex = (nextIndex + step) % numbers.Length;
                    }

                    if (currentSequence > maxSequence)
                    {
                        maxSequence = currentSequence;
                    }
                }
            }

            Console.WriteLine(maxSequence);
        }
    }
}
