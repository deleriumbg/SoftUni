using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_Reward
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());
            double moneyPerPoint = double.Parse(Console.ReadLine());
            double sum = 0;
            for (int i = 1; i <= parts; i++)
            {
                int points = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    sum += points * 2 * moneyPerPoint;
                }
                else
                {
                    sum += points * moneyPerPoint;
                }
            }
            Console.WriteLine($"The project prize was {sum:f2} lv.");
        }
    }
}
