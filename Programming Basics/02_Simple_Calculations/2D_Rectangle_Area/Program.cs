using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            var sideA = Math.Abs(x1 - x2);
            var sideB = Math.Abs(y1 - y2);
            var area = sideA * sideB;
            var perimeter = (sideA + sideB) * 2;
            Console.WriteLine(area);
            Console.WriteLine(perimeter);
        }
    }
}
