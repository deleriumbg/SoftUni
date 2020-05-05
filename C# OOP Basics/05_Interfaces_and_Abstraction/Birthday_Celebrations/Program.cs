using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IBirthday> birthdays = new List<IBirthday>();
        string[] inputArgs = Console.ReadLine().Split();

        while (inputArgs[0] != "End")
        {
            switch (inputArgs[0])
            {
                case "Citizen":
                    IBirthday citizen = new Citizen(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                    birthdays.Add(citizen);
                    break;
                case "Pet":
                    IBirthday pet = new Pet(inputArgs[1], inputArgs[2]);
                    birthdays.Add(pet);
                    break;
            }
            inputArgs = Console.ReadLine().Split();
        }

        string birthdayYearQuery = Console.ReadLine();
        foreach (var citizenOrPet in birthdays.Where(x => x.Birthday.EndsWith(birthdayYearQuery)))
        {
            Console.WriteLine(citizenOrPet.Birthday);
        }
    }
}
