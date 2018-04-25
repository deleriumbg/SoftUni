using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stupid_Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());

            int char3 = 97 + l;
            int char4 = 97 + l;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; i++)
                {
                    for (int k = 97; k <= char3; k++)
                    {
                        for (int m = 97; m <= char4; m++)
                        {
                            for (int p = 1; p <= n; p++)
                            {
                                if (p > i && p > j)
                                {
                                    Console.Write("{0}{1}{2}{3}{4} ", i, j, (char)k, (char)m, p);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
