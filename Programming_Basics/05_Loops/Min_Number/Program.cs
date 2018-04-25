using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstNum = int.Parse(Console.ReadLine());
            int minNum = firstNum;

            for (int i = 1; i <= n - 1; i++)
            {
                int nextNum = int.Parse(Console.ReadLine());
                if (nextNum < minNum)
                {
                    minNum = nextNum;
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
