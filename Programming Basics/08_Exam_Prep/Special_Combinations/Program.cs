using System;

namespace Special_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int hundreds = int.Parse(Console.ReadLine());
            int decimals = int.Parse(Console.ReadLine());
            int singles = int.Parse(Console.ReadLine());
            
            for (int hundred = 2; hundred <= hundreds; hundred += 2)
            {
                for (int deci = 2; deci <= decimals; deci++)
                {
                    if (deci == 2 || deci == 3 || deci == 5 || deci == 7)
                    {
                        for (int single = 2; single <= singles; single += 2)
                        {
                            Console.WriteLine($"{hundred} {deci} {single}");
                        }
                    }
                }
            }
        }
    }
}
