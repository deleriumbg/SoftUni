using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<ISoldier> soldiers = new List<ISoldier>();

        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] soldierInfo = input.Split();
            string soldierType = soldierInfo[0];
            int id = int.Parse(soldierInfo[1]);
            string firstName = soldierInfo[2];
            string lastName = soldierInfo[3];
            double salary = double.Parse(soldierInfo[4]);

            ISoldier soldier = null;
            try
            {
                switch (soldierType)
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    case "Spy":
                        soldier = new Spy(id, firstName, lastName, (int)salary);
                        break;
                    case "LeutenantGeneral":
                        LeutenantGeneral lieutenant = new LeutenantGeneral(id, firstName, lastName, salary);

                        for (int i = 5; i < soldierInfo.Length; i++)
                        {
                            int privateId = int.Parse(soldierInfo[i]);
                            ISoldier currentPrivate = soldiers.First(x => x.Id == privateId);
                            lieutenant.AddPrivate(currentPrivate);
                        }
                        soldier = lieutenant;
                        break;
                    case "Engineer":
                        string engineerCorps = soldierInfo[5];
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);

                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string repairPart = soldierInfo[i];
                            int repairHours = int.Parse(soldierInfo[i + 1]);
                            IRepair repair = new Repair(repairPart, repairHours);
                            engineer.AddRepair(repair);
                        }
                        soldier = engineer;
                        break;
                    case "Commando":
                        string commandoCorps = soldierInfo[5];
                        Commando commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string codeName = soldierInfo[i];
                            string state = soldierInfo[i + 1];
                            try
                            {
                                IMission mission = new Mission(codeName, state);
                                commando.AddMission(mission);
                            }
                            catch { }
                            
                        }
                        soldier = commando;
                        break;
                    default:
                        throw new ArgumentException("Invalid soldier type!");
                }
                soldiers.Add(soldier);
            }
            catch (ArgumentException) { }

            input = Console.ReadLine();
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}
