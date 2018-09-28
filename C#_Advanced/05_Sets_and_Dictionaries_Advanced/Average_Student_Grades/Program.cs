using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string studentName = studentInfo[0];
                double studentGrade = double.Parse(studentInfo[1]);

                if (!grades.ContainsKey(studentName))
                {
                    grades.Add(studentName, new List<double>());
                }
                grades[studentName].Add(studentGrade);
            }

            foreach (var item in grades)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(" ", item.Value.Select(i => i.ToString("F2")))} (avg: {item.Value.Average():F2})");
            }
        }
    }
}
