using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string yearType = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int sofiaWeekends = 48 - h;
            double sofiaGames = (sofiaWeekends * 3.0) / 4;
            double homeGames = h;
            double holidayGames = (p * 2.0) / 3;

            double allGames = homeGames + holidayGames + sofiaGames;
            if (yearType == "leap")
            {
                allGames *= 1.15;
            }
            Console.WriteLine(Math.Truncate(allGames));
        }
    }
}
