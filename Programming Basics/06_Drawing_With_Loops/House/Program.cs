using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int starsCount = 1;
            if (n % 2 == 0)
            {
                starsCount = 2;
            }

            for (int row = 1; row <= (n + 1) / 2; row++)
            {
                string stars = new string('*', starsCount);
                string dashes = new string('-', (n - starsCount) / 2);
                string roofRow = $"{dashes}{stars}{dashes}";
                Console.WriteLine(roofRow);
                starsCount += 2;
            }

            int bottomStars = n - 2;

            for (int row = 1; row <= n / 2; row++)
            {
                string bottomRow = ('|' + new string('*', bottomStars) + '|');
                Console.WriteLine(bottomRow);
            }
        }
    }
}
