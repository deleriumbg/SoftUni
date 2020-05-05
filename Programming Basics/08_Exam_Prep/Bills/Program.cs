using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double totalElectricity = 0;
            double totalWater = months * 20;
            double totalInternet = months * 15;
            double totalOther = 0;
            for (int i = 0; i < months; i++)
            {
                double electricity = double.Parse(Console.ReadLine());
                double other = 0;
                totalElectricity += electricity;
                other = (electricity + 20 + 15) * 1.2;
                totalOther += other;
            }
            Console.WriteLine($"Electricity: {totalElectricity:f2} lv\r\nWater: {totalWater:f2} lv\r\nInternet: {totalInternet:f2} lv\r\nOther: {totalOther:f2} lv");
            Console.WriteLine($"Average: {(totalElectricity + totalWater + totalInternet + totalOther) / months:f2} lv");
        }
    }
}
