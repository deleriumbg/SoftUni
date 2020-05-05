using System;
using System.Linq;
using System.Text;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplyer = int.Parse(Console.ReadLine());
            if (multiplyer == 0)
            {
                Console.WriteLine("0");
                return;
            }
            StringBuilder result = new StringBuilder();
            int sum = 0;
            int num = 0;
            int remainder = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                sum = (number[i] - 48) * multiplyer + remainder;
                num = sum % 10;
                if (sum > 9)
                {
                    remainder = sum / 10;
                }
                else
                {
                    remainder = 0;
                }
                result.Append(num);
            }
            if (remainder > 0)
            {
                result.Append(remainder);
            }
            Console.WriteLine(result.ToString().TrimEnd('0').ToCharArray().Reverse().ToArray());
        }
    }
}
