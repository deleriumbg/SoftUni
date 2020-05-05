using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Student_Groups
{
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Town> towns = ReadTownsAndStudents();
            List<Group> groups = DistributeStudentsIntoGroups(towns);

            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");
            foreach (var group in groups.OrderBy(x => x.Town.Name))
            {
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", group.Students.Select(x => x.Email).ToList())}");
            }
        }

        private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            List<Group> groups = new List<Group>();

            foreach (var town in towns)
            {
                IEnumerable<Student> students = town.Students.OrderBy(x => x.RegistrationDate)
                    .ThenBy(x => x.Name).ThenBy(x => x.Email);

                while (students.Any())
                {
                    Group group = new Group();
                    group.Town = town;
                    group.Students = students.Take(group.Town.SeatsCount).ToList();
                    students = students.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }
            return groups;
        }

        private static List<Town> ReadTownsAndStudents()
        {
            string inputLine = Console.ReadLine();
            List<Town> towns = new List<Town>();
            List<Student> students = new List<Student>();

            while (inputLine != "End")
            {
                if (inputLine.Contains("=>"))
                {
                    Town town = new Town();
                    string[] townArgs = inputLine.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    string townName = townArgs[0].Trim();
                    string[] seatArgs = townArgs[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int seatCount = int.Parse(seatArgs[0].Trim());

                    town.Name = townName;
                    town.SeatsCount = seatCount;
                    town.Students = new List<Student>();
                    towns.Add(town);
                }
                else
                {
                    Student student = new Student();
                    string[] studentArgs = inputLine.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string studentName = studentArgs[0].Trim();
                    string email = studentArgs[1].Trim();
                    DateTime date = DateTime.ParseExact(studentArgs[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    student.Name = studentName;
                    student.Email = email;
                    student.RegistrationDate = date;
                    towns.Last().Students.Add(student);
                }
                inputLine = Console.ReadLine();
            }
            return towns;
        }
    }
}
