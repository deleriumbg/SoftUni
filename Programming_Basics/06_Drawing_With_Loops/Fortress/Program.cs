using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortress
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int width = 2 * n;
            int topArrows = n / 2;
            int midSpace = width - (2 * topArrows) - 4;
            string topRow = '/' + new string('^', topArrows) + '\\' + new string('_', midSpace) + '/' + new string('^', topArrows) + '\\';
            Console.WriteLine(topRow);

            int widthSpaces = (2 * n) - 2;
            for (int i = 1; i < n - 2; i++)
            {
                string row = '|' + new string(' ', widthSpaces) + '|';
                Console.WriteLine(row, i);
            }

            string beforeLastRow = '|' + new string(' ', topArrows) + ' ' + new string('_', midSpace) + ' ' + new string(' ', topArrows) + '|';
            Console.WriteLine(beforeLastRow);
            string bottomRow = '\\' + new string('_', topArrows) + '/' + new string(' ', midSpace) + '\\' + new string('_', topArrows) + '/';
            Console.WriteLine(bottomRow);
        }
    }
}
