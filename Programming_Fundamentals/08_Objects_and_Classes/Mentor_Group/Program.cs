using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Mentor_Group
{
    class Student
    {
        public string Name { get; set; }
        public List<string> Comments { get; set; }
        public List<DateTime> AttendanceDates { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "end of dates")
            {
                Student student = new Student();

                string[] studentInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = studentInfo[0];
                List<DateTime> dates = new List<DateTime>();

                if (studentInfo.Length > 1)
                {
                    dates = studentInfo[1].Split(',').Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
                }
              
                if (!students.Any(x => x.Name == name))
                {
                    student.Name = name;
                    student.AttendanceDates = dates;
                    student.Comments = new List<string>();
                    students.Add(student);
                }
                else
                {
                    Student existingStudent = students.Find(x => x.Name == name);
                    existingStudent.AttendanceDates.AddRange(dates);
                }

                input = Console.ReadLine();
            }

            string commentsInput = Console.ReadLine();

            while (commentsInput != "end of comments")
            {
                string[] commentArgs = commentsInput.Split('-');
                string commentName = commentArgs[0];
                string comment = commentArgs[1];

                if (students.Any(x => x.Name == commentName))
                {
                    Student student = students.Find(x => x.Name == commentName);
                    student.Comments.Add(comment);
                }

                commentsInput = Console.ReadLine();
            }

            foreach (var student in students.OrderBy(x => x.Name))
            {
                Console.WriteLine(student.Name);

                Console.WriteLine("Comments:");
                if (student.Comments != null)
                {
                    foreach (var comment in student.Comments)
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }

                Console.WriteLine("Dates attended:");
                if (student.AttendanceDates != null)
                {
                    foreach (var date in student.AttendanceDates.OrderBy(x => x))
                    {
                        Console.WriteLine($"-- {date.ToString("dd/MM/yyyy")}");
                    }
                } 
            }
        }
    }
}
