using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Armada
{
    class Legion
    {
        public int Activity { get; set; }
        public string Name { get; set; }
        public Dictionary<string, long> Soldiers { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Legion> legions = new List<Legion>();

            for (int i = 0; i < N; i++)
            {
                string[] soldierInfo = Console.ReadLine().Split(new []{ '=', '-', '>', ':', ' ' },StringSplitOptions.RemoveEmptyEntries);
                int lastActivity = int.Parse(soldierInfo[0]);
                string legionName = soldierInfo[1];
                string soldierType = soldierInfo[2];
                int soldierCount = int.Parse(soldierInfo[3]);
                Legion legion = new Legion();

                if (legions.All(x => x.Name != legionName))
                {
                    legion.Name = legionName;
                    legion.Activity = lastActivity;
                    legion.Soldiers = new Dictionary<string, long> {{soldierType, soldierCount}};
                    legions.Add(legion);
                }
                else
                {
                    Legion existingLegion = legions.First(x => x.Name == legionName);
                    if (lastActivity > existingLegion.Activity)
                    {
                        existingLegion.Activity = lastActivity;
                    }
                    if (!existingLegion.Soldiers.ContainsKey(soldierType))
                    {
                        existingLegion.Soldiers.Add(soldierType, soldierCount);
                    }
                    else
                    {
                        existingLegion.Soldiers[soldierType] += soldierCount;
                    }
                }
            }

            string command = Console.ReadLine();
            if (command.Contains('\\'))
            {
                string[] commandArgs = command.Split('\\');
                int maxActivity = int.Parse(commandArgs[0]);
                string typeQuery = commandArgs[1];
                legions = legions.Where(x => x.Activity < maxActivity && x.Soldiers.ContainsKey(typeQuery)).ToList();
                foreach (var legion in legions.OrderByDescending(x => x.Soldiers[typeQuery]))
                {
                    Console.WriteLine($"{legion.Name} -> {legion.Soldiers[typeQuery]}");
                }
            }
            else
            {
                legions = legions.Where(x => x.Soldiers.ContainsKey(command)).ToList();
                foreach (var legion in legions.OrderByDescending(x => x.Activity))
                {
                    Console.WriteLine($"{legion.Activity} : {legion.Name}");
                }
            }
        }
    }
}
