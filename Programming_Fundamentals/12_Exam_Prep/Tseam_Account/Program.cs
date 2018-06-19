using System;
using System.Collections.Generic;
using System.Linq;

namespace Tseam_Account
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> games = Console.ReadLine().Split(' ').ToList();
            string input = Console.ReadLine();

            while (input != "Play!")
            {
                string[] commands = input.Split(' ');
                string command = commands[0];
                string game = commands[1];
                switch (command)
                {
                    case "Install":
                        if (!games.Contains(game))
                        {
                            games.Add(game);
                        }
                        break;
                    case "Uninstall":
                        games.Remove(game);
                        break;
                    case "Update":
                        if (games.Contains(game))
                        {
                            games.Remove(game);
                            games.Add(game);
                        }  
                        break;
                    case "Expansion":
                        string[] expansionInfo = game.Split('-');
                        string expandedGame = expansionInfo[0];
                        string expansion = expansionInfo[1];
                        if (games.Any(g => g == expandedGame))
                        {
                            int indexOfGame = games.IndexOf(expandedGame);
                            games.Insert(indexOfGame + 1, $"{expandedGame}:{expansion}");
                        }
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", games));
        }
    }
}
