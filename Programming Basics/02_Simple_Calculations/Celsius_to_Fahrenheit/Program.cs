using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            var cels = double.Parse(Console.ReadLine());
            var fahr = cels * 1.8 + 32;
            Console.WriteLine(Math.Round(fahr, 2));
        }
    }
}
