using System;

namespace Swimming_World_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeMPerS = double.Parse(Console.ReadLine());

            double swimmingTime = distance * timeMPerS;
            int slowDowns = (int)Math.Floor(distance / 15);
            double additionalTime = slowDowns * 12.5;
            double totalTime = swimmingTime + additionalTime;
            if (totalTime < record)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {totalTime - record:f2} seconds slower.");
            }
        }
    }
}
