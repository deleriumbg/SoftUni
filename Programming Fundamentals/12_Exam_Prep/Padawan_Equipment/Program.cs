using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
            double totalLightsabersPrice = 0.0;
            if (students % 10 == 0)
            {
                totalLightsabersPrice = lightsaberPrice * (students + (students / 10));
            }
            else
            {
                totalLightsabersPrice = lightsaberPrice * (students + (students / 10) + 1);
            }
            double totalRobesPrice = robePrice * students;
            double totalBeltsPrice = beltPrice * (students - (students / 6));
            double totalSpent = totalLightsabersPrice + totalRobesPrice + totalBeltsPrice;

            Console.WriteLine(money >= totalSpent
                ? $"The money is enough - it would cost {totalSpent:f2}lv."
                : $"Ivan Cho will need {totalSpent - money:f2}lv more.");
        }
    }
}
