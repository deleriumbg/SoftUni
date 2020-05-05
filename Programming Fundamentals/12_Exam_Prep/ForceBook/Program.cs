using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, HashSet<string>> sides = new Dictionary<string, HashSet<string>>();

            while (input != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] usersInfo = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = usersInfo[0].Trim();
                    string forceUser = usersInfo[1].Trim();
                    if (!sides.ContainsKey(forceSide))
                    {
                        HashSet<string> users = new HashSet<string>();
                        users.Add(forceUser);
                        sides.Add(forceSide, users);
                    }
                    else if (!sides[forceSide].Contains(forceUser))
                    {
                        sides[forceSide].Add(forceUser);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] usersInfo = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
                    string forceUser = usersInfo[0].Trim();
                    string forceSide = usersInfo[1].Trim();
                    if (sides.Any(x => x.Value.Contains(forceUser)))
                    {
                        if (!sides.ContainsKey(forceSide))
                        {
                            sides[forceSide] = new HashSet<string>();
                        }
                        string sideToRemove = sides.First(x => x.Value.Contains(forceUser)).Key;
                        sides[sideToRemove].Remove(forceUser);
                        sides[forceSide].Add(forceUser);
                    }
                    else
                    {
                        if (!sides.ContainsKey(forceSide))
                        {
                            sides[forceSide] = new HashSet<string>();
                        }
                        sides[forceSide].Add(forceUser);
                    }
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            foreach (var side in sides.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}