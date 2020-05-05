using System;

namespace Trainers_Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int lectures = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int jelev = 0;
            int royal = 0;
            int roli = 0;
            int trofon = 0;
            int sino = 0;
            int other = 0;

            for (int i = 0; i < lectures; i++)
            {
                string lector = Console.ReadLine();
                switch (lector)
                {
                    case "Jelev":
                        jelev++;
                        break;
                    case "RoYaL":
                        royal++;
                        break;
                    case "Roli":
                        roli++;
                        break;
                    case "Trofon":
                        trofon++;
                        break;
                    case "Sino":
                        sino++;
                        break;
                    default:
                        other++;
                        break;
                }
            }
            double moneyPerLecture = budget / lectures;
            Console.WriteLine($"Jelev salary: {jelev * moneyPerLecture:f2} lv\r\nRoYaL salary: {royal * moneyPerLecture:f2} lv\r\nRoli salary: {roli * moneyPerLecture:f2} lv\r\nTrofon salary: {trofon * moneyPerLecture:f2} lv\r\nSino salary: {sino * moneyPerLecture:f2} lv\r\nOthers salary: {other * moneyPerLecture:f2} lv");
        }
    }
}
