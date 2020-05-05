using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] citizenInfo = input.Split();
            string name = citizenInfo[0];
            string country = citizenInfo[1];
            int age = int.Parse(citizenInfo[2]);

            IPerson person = new Citizen(name, country, age);
            IResident resident = new Citizen(name, country, age);

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());

            input = Console.ReadLine();
        }
    }
}
