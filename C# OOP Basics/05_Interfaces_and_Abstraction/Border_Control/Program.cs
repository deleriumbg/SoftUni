using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<IIdentifiable> population = new List<IIdentifiable>();
        string input = Console.ReadLine();

        while (input != "End")
        {
            string[] inputArgs = input.Split();
            switch (inputArgs.Length)
            {
                case 2:
                    IIdentifiable robot = new Robot(inputArgs[0], inputArgs[1]);
                    population.Add(robot);
                    break;
                case 3:
                    IIdentifiable citizen = new Citizen(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                    population.Add(citizen);
                    break;
            }
            input = Console.ReadLine();
        }

        string fakeIdLastDigits = Console.ReadLine();
        foreach (var citizenOrRobot in population.Where(x => x.Id.EndsWith(fakeIdLastDigits)))
        {
            Console.WriteLine(citizenOrRobot.Id);
        }
    }
}
