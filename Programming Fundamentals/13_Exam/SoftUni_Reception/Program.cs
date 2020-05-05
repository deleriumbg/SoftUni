using System;

namespace SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());

            int answersPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int hourCounter = 0;

            while (studentsCount > 0)
            {
                hourCounter++;
                studentsCount -= answersPerHour;
                if (hourCounter % 4 == 0)
                {
                    hourCounter++;
                }
            }

            Console.WriteLine($"Time needed: {hourCounter}h.");
        }
    }
}