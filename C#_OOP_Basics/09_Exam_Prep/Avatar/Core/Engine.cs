using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        while (true)
        {
            string input = Console.ReadLine();
            string[] inputArgs = input.Split();
            string command = inputArgs[0];
            List<string> args = inputArgs.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(args);
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(args);
                    break;
                case "Status":
                    Console.WriteLine(this.nationsBuilder.GetStatus(args[0]));
;                   break;
                case "War":
                    this.nationsBuilder.IssueWar(args[0]);
                    break;
                case "Quit":
                    Console.WriteLine(this.nationsBuilder.GetWarsRecord());
                    return;
            }
        }
    }
}
