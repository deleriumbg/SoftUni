using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Plus_15_min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());

            int newMin = min + 15;
            int newHour = hour;

            if (newMin > 59)
            {
                newHour = hour + 1;
                newMin = newMin - 60;
            }
            if (newHour > 23)
            {
                newHour = 0;
                newMin = (min + 15) - 60;
            }
            string result = (newHour + ":" + newMin.ToString("d2"));
            Console.WriteLine(result);
        }
    }
}
