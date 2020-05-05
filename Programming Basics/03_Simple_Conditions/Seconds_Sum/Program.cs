using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seconds_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double n3 = double.Parse(Console.ReadLine());

            double seconds = n1 + n2 + n3;

            if (seconds <= 59)
            {
                var sec = seconds.ToString("0:00");
                Console.WriteLine(sec);
            }
            else if (seconds >= 60 && seconds <= 119)
            {
                var sec = (seconds - 60).ToString("1:00");
                Console.WriteLine(sec);
            }
            else if (seconds >= 120 && seconds <= 179)
            {
                var sec = (seconds - 120).ToString("2:00");
                Console.WriteLine(sec);
            }
        }
    }
}
