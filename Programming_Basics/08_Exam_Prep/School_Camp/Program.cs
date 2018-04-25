using System;

namespace School_Camp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int studentsCount = int.Parse(Console.ReadLine());
            int nightsCount = int.Parse(Console.ReadLine());
            double sum = 0;
            string sport = null;

            switch (season)
            {
                case "Winter":
                    if (groupType == "girls")
                    {
                        sport = "Gymnastics";
                        sum += studentsCount * nightsCount * 9.60;
                    }
                    else if (groupType == "boys")
                    {
                        sport = "Judo";
                        sum += studentsCount * nightsCount * 9.60;
                    }
                    else if (groupType == "mixed")
                    {
                        sport = "Ski";
                        sum += studentsCount * nightsCount * 10;
                    }
                    break;
                case "Spring":
                    if (groupType == "girls")
                    {
                        sport = "Athletics";
                        sum += studentsCount * nightsCount * 7.20;
                    }
                    else if (groupType == "boys")
                    {
                        sport = "Tennis";
                        sum += studentsCount * nightsCount * 7.20;
                    }
                    else if (groupType == "mixed")
                    {
                        sport = "Cycling";
                        sum += studentsCount * nightsCount * 9.50;
                    }
                    break;
                case "Summer":
                    if (groupType == "girls")
                    {
                        sport = "Volleyball";
                        sum += studentsCount * nightsCount * 15;
                    }
                    else if (groupType == "boys")
                    {
                        sport = "Football";
                        sum += studentsCount * nightsCount * 15;
                    }
                    else if (groupType == "mixed")
                    {
                        sport = "Swimming";
                        sum += studentsCount * nightsCount * 20;
                    }
                    break;
            }
            if (studentsCount >= 50)
            {
                sum *= 0.5;
            }
            else if (studentsCount >= 20 && studentsCount < 50)
            {
                sum *= 0.85;
            }
            else if (studentsCount >= 10 && studentsCount < 20)
            {
                sum *= 0.95;
            }
            Console.WriteLine($"{sport} {sum:f2} lv.");
        }
    }
}
