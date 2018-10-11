using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var departments = new Dictionary<string, List<string>>();
            var doctors = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "Output")
            {
                string department = input[0];
                string doctor = $"{input[1]} {input[2]}";
                string patient = input[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<string>());
                }
                departments[department].Add(patient);

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }
                doctors[doctor].Add(patient);

                input = Console.ReadLine().Split();
            }
            string[] command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                if (command.Length == 1)
                {
                    foreach (var patient in departments[command[0]])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    int roomNumber = 0;
                    if (int.TryParse(command[1], out roomNumber))
                    {
                        foreach (var patient in departments[command[0]].Skip(3 * (roomNumber - 1)).Take(3).OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        foreach (var patient in doctors[$"{command[0]} {command[1]}"].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}
