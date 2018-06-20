using System;
using System.Collections.Generic;
using System.Linq;

namespace MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Season end")
            {
                if (!input.Contains("vs"))
                {
                    string[] playerInfo = input.Split(new string[] { " -> " }, StringSplitOptions.None);
                    string player = playerInfo[0];
                    string position = playerInfo[1];
                    int skill = int.Parse(playerInfo[2]);

                    if (!players.ContainsKey(player))
                    {
                        players[player] = new Dictionary<string, int>();
                    }
                    if (!players[player].ContainsKey(position))
                    {
                        players[player].Add(position, skill);
                    }
                    else
                    {
                        if (players[player][position] < skill)
                        {
                            players[player][position] = skill;
                        }
                    }
                }

                else
                {
                    string[] duelInfo = input.Split(new string[] { " vs " }, StringSplitOptions.None);
                    string firstPlayer = duelInfo[0];
                    string secondPlayer = duelInfo[1];

                    if (players.ContainsKey(firstPlayer) && players.ContainsKey(secondPlayer))
                    {
                        if (players[firstPlayer].Any(x => players[secondPlayer].ContainsKey(x.Key)))
                        {
                            if (players[firstPlayer].Values.Sum() > players[secondPlayer].Values.Sum())
                            {
                                players.Remove(secondPlayer);
                            }
                            else
                            {
                                players.Remove(firstPlayer);
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var player in players.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");
                foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
}
