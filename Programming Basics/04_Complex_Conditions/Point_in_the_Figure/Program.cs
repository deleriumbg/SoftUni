using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_in_the_Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            var onLeftSide = (x == 0) && (y >= 0) && (y <= h);
            var onRightSide = (x == 3 * h) && (y >= 0) && (y <= h);
            var onUpSide = (y == h) && ((x >= 0 && x <= h) || (x >= 2 * h && x <= 3 * h));
            var onDownSide = (y == 0) && (x >= 0) && (x <= 3 * h);

            var onLeftSideTop = (x == h) && (y >= h) && (y <= 4 * h);
            var onRightSideTop = (x == 2 * h) && (y >= h) && (y <= 4 * h);
            var onTopSide = (y == 4 * h) && (x >= h) && (x <= 2 * h);

            if ((x > 0 && x < 3 * h && y > 0 && y < h) || (x > h && x < 2 * h && y > 0 && y < 4 * h))
            {
                Console.WriteLine("inside");
            }
            else if (onLeftSide || onLeftSideTop || onRightSide || onRightSideTop || onUpSide || onDownSide || onTopSide)
            {
                Console.WriteLine("border");
            }
            else
            {
                Console.WriteLine("outside");
            }
        }
    }
}
