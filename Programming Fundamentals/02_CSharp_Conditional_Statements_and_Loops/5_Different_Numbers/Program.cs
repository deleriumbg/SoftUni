using System;

namespace _5_Different_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            if (second - first < 5)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int n1 = first; n1 <= second; n1++)
                {
                    for (int n2 = first; n2 <= second; n2++)
                    {
                        for (int n3 = first; n3 <= second; n3++)
                        {
                            for (int n4 = first; n4 <= second; n4++)
                            {
                                for (int n5 = first; n5 <= second; n5++)
                                {
                                    if (first <= n1 && n1 < n2 && n2 < n3 && n3 < n4 && n4 < n5 && n5 <= second)
                                    {
                                        Console.Write($"{n1} {n2} {n3} {n4} {n5}");
                                        Console.WriteLine();
                                    }
                                }
                            }
                        }
                    }
                }
            } 
        }
    }
}
