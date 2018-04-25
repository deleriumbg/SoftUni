using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstNum = int.Parse(Console.ReadLine());
            int max = firstNum;

            for (int i = 1; i <= n - 1; i++)
            {
                int nextNumber = int.Parse(Console.ReadLine());
                if (nextNumber > max)
                {
                    max = nextNumber;
                }
            }
            Console.WriteLine(max);
            
        }
    }
}
