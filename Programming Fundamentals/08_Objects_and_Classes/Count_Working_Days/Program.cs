using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Count_Working_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            int counter = 0;
            List<DateTime> holidays = new List<DateTime>();
            holidays.Add(DateTime.ParseExact("01-01", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("03-03", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("01-05", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("06-05", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("24-05", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("06-09", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("22-09", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("01-11", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("24-12", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("25-12", "dd-MM", CultureInfo.InvariantCulture));
            holidays.Add(DateTime.ParseExact("26-12", "dd-MM", CultureInfo.InvariantCulture));

            for (DateTime currentDay = startDate; currentDay <= endDate; currentDay = currentDay.AddDays(1))
            {
                
                if (currentDay.DayOfWeek.Equals(DayOfWeek.Saturday) == false && currentDay.DayOfWeek.Equals(DayOfWeek.Sunday) == false && holidays.Any(x => x.Day == currentDay.Day && x.Month == currentDay.Month) == false)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
