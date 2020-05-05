using System;
using System.Collections.Generic;
using System.Linq;

namespace Handball_Statistics
{
    public class Team
    {
        public Team()
        { }

        public Team(string name, List<string> opponents, int wins)
        {
            Name = name;
            Opponents = opponents;
            Wins = wins;
        }

        public string Name { get; set; }
        public List<string> Opponents { get; set; }
        public int Wins { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Team> teams = new List<Team>();

            while (input != "stop")
            {
                string[] matchDetails = input.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string team1Name = matchDetails[0].Trim();
                string team2Name = matchDetails[1].Trim();
                int[] result1 = matchDetails[2].Trim().Split(':').Select(int.Parse).ToArray();
                int[] result2 = matchDetails[3].Trim().Split(':').Select(int.Parse).ToArray();

                if (!teams.Any(t => t.Name == team1Name))
                {
                    Team team = new Team();
                    team.Name = team1Name;
                    team.Wins += (team1Wins(result1, result2) ? 1 : 0);
                    team.Opponents = new List<string>();
                    team.Opponents.Add(team2Name);
                    teams.Add(team);
                }
                else
                {
                    Team existingTeam = teams.Find(t => t.Name == team1Name);
                    existingTeam.Wins += (team1Wins(result1, result2) ? 1 : 0);
                    existingTeam.Opponents.Add(team2Name);
                }

                if (!teams.Any(t => t.Name == team2Name))
                {
                    Team team = new Team();
                    team.Name = team2Name;
                    team.Wins += (team1Wins(result1, result2) ? 0 : 1);
                    team.Opponents = new List<string>();
                    team.Opponents.Add(team1Name);
                    teams.Add(team);
                }
                else
                {
                    Team existingTeam = teams.Find(t => t.Name == team2Name);
                    existingTeam.Wins += (team1Wins(result1, result2) ? 0 : 1);
                    existingTeam.Opponents.Add(team1Name);
                }

                input = Console.ReadLine();
            }

            foreach (var team in teams.OrderByDescending(x => x.Wins).ThenBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
                Console.WriteLine($"- Wins: {team.Wins}");
                Console.WriteLine($"- Opponents: {string.Join(", ", team.Opponents.OrderBy(x => x))}");
            }
        }

        private static bool team1Wins(int[] result1, int[] result2)
        {
            //After splitting the result arrays by ':'
            int team1Points = result1[0] + result2[1];
            int team2Points = result1[1] + result2[0];

            if (team1Points > team2Points)
            {
                return true;
            }
            else if (team1Points == team2Points)
            {
                if (result2[1] > result1[1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    } 
}
