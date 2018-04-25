using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _1000_Days
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateInput = Console.ReadLine();
            string format = "dd-MM-yyyy";
            DateTime date = DateTime.ParseExact(dateInput, format, CultureInfo.InvariantCulture);
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime newDate = date.AddDays(999);
            Console.WriteLine(newDate.ToString(format));
        }
    }
}
