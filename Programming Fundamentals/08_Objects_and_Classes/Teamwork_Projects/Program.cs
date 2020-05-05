using System;
using System.Collections.Generic;
using System.Linq;

namespace Teamwork_Projects
{
    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            List<Team> teams = new List<Team>();
            string creatorName = "";
            string teamName = "";
            for (int i = 0; i < n; i++)
            {
                string[] teamInfo = input.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                creatorName = teamInfo[0];
                teamName = teamInfo[1];
                Team team = new Team();
                if (teams.Any(x => x.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(x => x.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
                else
                {
                    team.Name = teamName;
                    team.Creator = creatorName;
                    List<string> members = new List<string>();
                    team.Members = members;
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
                input = Console.ReadLine();
            }
            
            string joinerName = "";
            string teamToJoin = "";
            while (input != "end of assignment")
            {
                string[] joiningInfo = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                joinerName = joiningInfo[0];
                teamToJoin = joiningInfo[1];
                if (teams.Any(x => x.Name == teamToJoin) == false)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                }
                else if (teams.Any(x => x.Members.Contains(joinerName)) || teams.Any(x => x.Creator == joinerName))
                {
                    Console.WriteLine($"Member {joinerName} cannot join team {teamToJoin}!");
                }
                else
                {
                    foreach (var team in teams.Where(x => x.Name == teamToJoin))
                    {
                        team.Members.Add(joinerName);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var team in teams.Where(x => x.Members.Count > 0).OrderBy(x => x.Name).OrderByDescending(x => x.Members.Count))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var person in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {person}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in teams.Where(x => x.Members.Count == 0).OrderBy(x => x.Name))
            {
                Console.WriteLine($"{team.Name}");
            }
        }
    }
}
