using System;
using System.Collections.Generic;
using System.Linq;

public class BePositive_broken
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());

        for (int i = 0; i < countSequences; i++)
        {
            List<int> numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> result = new List<int>();

            bool found = false;

            for (int index = 0; index < numbers.Count; index++)
            {
                int currentNum = numbers[index];

                if (currentNum >= 0)
                {
                    result.Add(currentNum);

                    found = true;
                }
                else
                {
                    if (index != numbers.Count - 1)
                    {
                        int added = currentNum + numbers[index + 1];
                        if (added >= 0)
                        {
                            result.Add(added);
                            index++;
                            found = true;
                        }
                        else
                        {
                            index++;
                            continue;
                        }
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}