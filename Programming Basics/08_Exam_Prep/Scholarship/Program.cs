using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimumWage = double.Parse(Console.ReadLine());
            bool social = income < minimumWage && averageGrade > 4.5;
            bool grade = averageGrade >= 5.5;
            if (!social && !grade)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (social && !grade)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(minimumWage * 0.35):f0} BGN");
            }
            else if (!social && grade)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(averageGrade * 25):f0} BGN");
            }
            else if (social && grade)
            {
                if (averageGrade * 25 >= minimumWage * 0.35)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(averageGrade * 25):f0} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(minimumWage * 0.35):f0} BGN");
                }
            }
        }
    }
}
