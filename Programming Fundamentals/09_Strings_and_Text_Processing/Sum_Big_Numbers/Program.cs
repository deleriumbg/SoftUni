using System;
using System.Linq;
using System.Text;

namespace Sum_Big_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            string num2 = Console.ReadLine();
            
            if (num1.Length > num2.Length)
            {
                num2 = num2.PadLeft(num1.Length, '0');
            }
            else if (num1.Length < num2.Length)
            {
                num1 = num1.PadLeft(num2.Length, '0');
            }
            int remainder = 0;
            int sum = 0;
            int num = 0;
            StringBuilder result = new StringBuilder();
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                sum = num1[i] - 48 + num2[i] - 48 + remainder;
                num = sum % 10;
                if (sum <= 9)
                {
                    remainder = 0;
                }
                else
                {
                    remainder = 1;
                }
                result.Append(num);
            }
            if (remainder == 1)
            {
                result.Append(remainder);
            }

            Console.WriteLine(ReverseString(result.ToString().TrimEnd('0')));
        }

        public static string ReverseString(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
    }
}
