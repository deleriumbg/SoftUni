using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string department = ParseInput(command, out string firstName, out string lastName, out string patientName, out string fullName);
                AddDoctor(doctors, firstName, lastName, fullName);
                AddDepartment(departments, department);
                CheckForFreeRoom(departments, department, doctors, fullName, patientName);
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            PrintPatients(command, departments, doctors);
        }

        private static void PrintPatients(string command, Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
        {
            while (command != "End")
            {
                ParseResultCommand(command, departments, doctors);
                command = Console.ReadLine();
            }
        }

        private static void ParseResultCommand(string command, Dictionary<string, List<List<string>>> departments, Dictionary<string, List<string>> doctors)
        {
            string[] args = command.Split();

            switch (args.Length)
            {
                case 1:
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                    break;
                case 2 when int.TryParse(args[1], out int room):
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                    break;
                default:
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                    break;
            }
        }

        private static void CheckForFreeRoom(Dictionary<string, List<List<string>>> departments, string department, Dictionary<string, List<string>> doctors, string fullName,
            string patientName)
        {
            bool hasFreeBed = departments[department].SelectMany(x => x).Count() < 60;
            if (hasFreeBed)
            {
                SetPatientToDoctor(doctors, fullName, patientName);
                SetPatientToRoom(departments, department, patientName);
            }
        }

        private static void SetPatientToRoom(Dictionary<string, List<List<string>>> departments, string department, string patientName)
        {
            int rooms = 0;
            for (int currentRoom = 0; currentRoom < departments[department].Count; currentRoom++)
            {
                if (departments[department][currentRoom].Count < 3)
                {
                    rooms = currentRoom;
                    break;
                }
            }
            departments[department][rooms].Add(patientName);
        }

        private static void SetPatientToDoctor(Dictionary<string, List<string>> doctors, string fullName, string patientName)
        {
            doctors[fullName].Add(patientName);
        }

        private static void AddDepartment(Dictionary<string, List<List<string>>> departments, string department)
        {
            if (!departments.ContainsKey(department))
            {
                departments[department] = new List<List<string>>();
                for (int stai = 0; stai < 20; stai++)
                {
                    departments[department].Add(new List<string>());
                }
            }
        }

        private static void AddDoctor(Dictionary<string, List<string>> doctors, string firstName, string lastName, string fullName)
        {
            if (!doctors.ContainsKey(firstName + lastName))
            {
                doctors[fullName] = new List<string>();
            }
        }

        private static string ParseInput(string command, out string firstName, out string lastName, out string patientName,
            out string fullName)
        {
            string[] tokens = command.Split();
            var department = tokens[0];
            firstName = tokens[1];
            lastName = tokens[2];
            patientName = tokens[3];
            fullName = firstName + lastName;
            return department;
        }
    }
}
