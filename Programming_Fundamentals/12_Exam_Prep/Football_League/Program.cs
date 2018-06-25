using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Football_League
{
    class Team
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Goals { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string key = Regex.Escape(Console.ReadLine());
            string input = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (input != "final")
            {
                //Example: the key: “???”;
                //String to decrypt: “kfle???airagluB???gertIt%%” -> “airagluB” -> “Bulgaria”

                string pattern = $"{key}(.*?){key}.+?{key}(.*?){key}.+?([0-9]+:[0-9]+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    string team1 = match.Groups[1].Value;
                    string team2 = match.Groups[2].Value;
                    team1 = Reverse(team1).ToUpper();
                    team2 = Reverse(team2).ToUpper();
                    
                    string result = match.Groups[3].Value;
                    DistributePoints(team1, team2, result, teams);
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("League standings:");
            int counter = 1;
            foreach (var team in teams.OrderByDescending(x => x.Points).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{counter++}. {team.Name} {team.Points}");
            }

            var filtered = teams.OrderByDescending(x => x.Goals).ThenBy(x => x.Name).Take(3);
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in filtered)
            {
                Console.WriteLine($"- {team.Name} -> {team.Goals}");
            }
        }

        private static void DistributePoints(string team1, string team2, string result, List<Team> teams)
        {
            int[] score = result.Split(':').Select(int.Parse).ToArray();

            if (teams.All(x => x.Name != team1))
            {
                Team firstTeam = new Team();
                firstTeam.Name = team1;
                if (score[0] > score[1])
                {
                    firstTeam.Points += 3;
                    firstTeam.Goals += score[0];
                }
                else if (score[0] < score[1])
                {
                    firstTeam.Goals += score[0];
                }
                else
                {
                    firstTeam.Points += 1;
                    firstTeam.Goals += score[0];
                }
                teams.Add(firstTeam);
            }
            else
            {
                Team existingFirstTeam = teams.First(x => x.Name == team1);
                if (score[0] > score[1])
                {
                    existingFirstTeam.Points += 3;
                    existingFirstTeam.Goals += score[0];
                }
                else if (score[0] < score[1])
                {
                    existingFirstTeam.Goals += score[0];
                }
                else
                {
                    existingFirstTeam.Points += 1;
                    existingFirstTeam.Goals += score[0];
                }
            }

            if (teams.All(x => x.Name != team2))
            {
                Team secondTeam = new Team();
                secondTeam.Name = team2;
                if (score[1] > score[0])
                {
                    secondTeam.Points += 3;
                    secondTeam.Goals += score[1];
                }
                else if (score[1] < score[0])
                {
                    secondTeam.Goals += score[1];
                }
                else
                {
                    secondTeam.Points += 1;
                    secondTeam.Goals += score[1];
                }
                teams.Add(secondTeam);
            }
            else
            {
                Team existingSecondTeam = teams.First(x => x.Name == team2);
                if (score[1] > score[0])
                {
                    existingSecondTeam.Points += 3;
                    existingSecondTeam.Goals += score[1];
                }
                else if (score[1] < score[0])
                {
                    existingSecondTeam.Goals += score[1];
                }
                else
                {
                    existingSecondTeam.Points += 1;
                    existingSecondTeam.Goals += score[1];
                }
            }
        }

        public static string Reverse(string text)
        {
            if (text == null) return null;
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}
