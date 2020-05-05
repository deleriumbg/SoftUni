using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int numLength = num.ToString().Length;
            int sum = 0;
            int lastDigit;

            for (int i = numLength; i > 0; i--)
            {
                lastDigit = num % 10;
                sum = sum + lastDigit;
                num /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
