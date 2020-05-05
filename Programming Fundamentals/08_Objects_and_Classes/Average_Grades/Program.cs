using System;
using System.Collections.Generic;
using System.Linq;

namespace Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                List<string> input = Console.ReadLine().Split().ToList();
                string name = input[0];
                List<double> grades = input.Skip(1).Select(double.Parse).ToList();
                student.Name = name;
                student.Grades = grades;
                students.Add(student);
            }

            foreach (var student in students.Where(x => x.Average >= 5).OrderBy(x => x.Name).ThenByDescending(x => x.Average))
            {
                Console.WriteLine($"{student.Name} -> {student.Average:f2}");
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double Average { get { return Grades.Average(); } }
    }
}
