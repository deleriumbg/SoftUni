using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_0_100_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] rounds = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 0 || number > 100)
            {
                Console.WriteLine("invalid number");
            }
            else if (number >= 0 && number <= 9)
            {
                Console.WriteLine(digits[number]);
            }
            else if (number >= 10 && number <= 19)
            {
                Console.WriteLine(tens[number - 10]);
            }
            else if (number >= 20 && number <= 99)
            {
                if (number % 10 == 0)
                {
                    Console.WriteLine(rounds[number / 10 - 2]);
                }
                else
                {
                    Console.WriteLine(rounds[number / 10 - 2] + " " + digits[number % 10]);
                }
            }
            else
                Console.WriteLine("one hundred");
           
        }
    }
}
