using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            double unit = double.Parse(Console.ReadLine());
            string input = Console.ReadLine().ToLower();
            string output = Console.ReadLine().ToLower();

            switch (input)
            {
                case "m":
                    unit = unit / 1;
                    break;
                case "mm":
                    unit = unit / 1000;
                    break;
                case "cm":
                    unit = unit / 100;
                    break;
                case "mi":
                    unit = unit / 0.000621371192;
                    break;
                case "in":
                    unit = unit / 39.3700787;
                    break;
                case "km":
                    unit = unit / 0.001;
                    break;
                case "ft":
                    unit = unit / 3.2808399;
                    break;
                case "yd":
                    unit = unit / 1.0936133;
                    break;
            }
            switch (output)
            {
                case "m":
                    unit = unit * 1;
                    break;
                case "mm":
                    unit = unit * 1000;
                    break;
                case "cm":
                    unit = unit * 100;
                    break;
                case "mi":
                    unit = unit * 0.000621371192;
                    break;
                case "in":
                    unit = unit * 39.3700787;
                    break;
                case "km":
                    unit = unit * 0.001;
                    break;
                case "ft":
                    unit = unit * 3.2808399;
                    break;
                case "yd":
                    unit = unit * 1.0936133;
                    break;
            }
            string result = unit.ToString("f8");
            Console.WriteLine(result);
        }
    }
}
