using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = double.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            var output = Console.ReadLine();
            var bgn = 1.0;
            var usd = 1.79549;
            var eur = 1.95583;
            var gbp = 2.53405;
            switch (input)
            {
                case "BGN":
                    break;
                case "USD":
                    value = value * usd;
                    break;
                case "EUR":
                    value = value * eur;
                    break;
                case "GBP":
                    value = value * gbp;
                    break;
                default:
                    break;
            }
            switch (output)
            {
                case "BGN":
                    value = value / bgn;
                    break;
                case "USD":
                    value = value / usd;
                    break;
                case "EUR":
                    value = value / eur;
                    break;
                case "GBP":
                    value = value / gbp;
                    break;
                default:
                    break;
            }
            Console.WriteLine(Math.Round(value, 2) + " " + output);


        }
    }
}
