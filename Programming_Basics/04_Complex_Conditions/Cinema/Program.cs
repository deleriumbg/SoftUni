using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            int size = rows * col;

            if (type == "Premiere")
            {
                double result = size * 12;
                Console.WriteLine(result.ToString("0.00") + " leva");
            }
            else if (type == "Normal")
            {
                double result = size * 7.5;
                Console.WriteLine(result.ToString("0.00") + " leva");
            }
            else if (type == "Discount")
            {
                double result = size * 5;
                Console.WriteLine(result.ToString("0.00") + " leva");
            }
        }
    }
}
