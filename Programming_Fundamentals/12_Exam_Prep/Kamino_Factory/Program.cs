using System;
using System.Linq;

namespace Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int seqLength = int.Parse(Console.ReadLine());

            int[] bestSequence = new int[seqLength];

            int bestSeqLength = 0;
            int bestSeqIndex = 0;
            int bestSeqSum = 0;
            int bestSeqCounter = 0;

            int seqCounter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }

                int[] sequence = input
                    .Trim()
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                seqCounter++;

                int maxLength = 0;
                int bestIndex = 0;

                int currLength = 0;
                int startIndex = 0;
                int sum = 0;

                for (int i = 0; i < seqLength; i++)
                {
                    if (sequence[i] == 1)
                    {
                        currLength++;
                        sum++;

                        if (currLength == 1)
                        {
                            startIndex = i;
                        }

                        if (currLength > maxLength)
                        {
                            maxLength = currLength;
                            bestIndex = startIndex;
                        }
                    }
                    else
                    {
                        currLength = 0;
                        startIndex = 0;
                    }
                }

                bool isCurrentSeqBest = false;

                if (maxLength > bestSeqLength)
                {
                    isCurrentSeqBest = true;
                }
                else if (maxLength == bestSeqLength)
                {
                    if (bestIndex < bestSeqIndex)
                    {
                        isCurrentSeqBest = true;
                    }
                    else if (bestIndex == bestSeqIndex)
                    {
                        if (sum > bestSeqSum)
                        {
                            isCurrentSeqBest = true;
                        }
                    }
                }

                if (isCurrentSeqBest)
                {
                    bestSeqLength = maxLength;
                    bestSeqIndex = bestIndex;
                    bestSeqSum = sum;
                    bestSeqCounter = seqCounter;

                    for (int i = 0; i < seqLength; i++)
                    {
                        bestSequence[i] = sequence[i];
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSeqCounter} with sum: {bestSeqSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
}
