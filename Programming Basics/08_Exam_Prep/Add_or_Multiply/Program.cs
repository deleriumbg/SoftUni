using System;

namespace Add_or_Multiply
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlNumber = int.Parse(Console.ReadLine());
            bool isFound = false;
            for (int i = 1; i <= 30; i++)
            {
                for (int j = 1; j <= 30; j++)
                {
                    for (int k = 1; k <= 30; k++)
                    {
                        if (i + j + k == controlNumber && i < j && j < k)
                        {
                            isFound = true;
                            Console.WriteLine($"{i} + {j} + {k} = {controlNumber}");
                        }
                        else if (i * j * k == controlNumber && i > j && j > k)
                        {
                            isFound = true;
                            Console.WriteLine($"{i} * {j} * {k} = {controlNumber}");
                        }
                    }
                }
            }
            if (!isFound)
            {
                Console.WriteLine("No!");
            }
        }
    }
}
