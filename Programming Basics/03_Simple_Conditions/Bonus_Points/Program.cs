using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double bonus = 0;

            if (number <= 100)
            {
                bonus = 5;
            }
            else if (number > 100 && number < 1000)
            {
                bonus = number / 5;
            }
            else if (number >= 1000)
            {
                bonus = number / 10;
            }

            if (number % 2 == 0)
            {
                bonus += 1;
            }
            else if (number % 5 == 0 && number % 2 != 0)
            {
                bonus += 2;
            }

            string bunusResult = bonus.ToString("f1");
            string totalResult = (number + bonus).ToString("f1");
          
            Console.WriteLine(bunusResult);
            Console.WriteLine(totalResult);
        }
    }
}
