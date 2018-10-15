using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var users = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                if (input.StartsWith("ban"))
                {
                    string banned = input.Split()[1];
                    if (users.ContainsKey(banned))
                    {
                        users.Remove(banned);
                    }
                    input = Console.ReadLine();
                    continue;
                }

                string[] inputArgs = input.Split(" -> ");
                string username = inputArgs[0];
                string tag = inputArgs[1];
                int likes = int.Parse(inputArgs[2]);

                if (!users.ContainsKey(username))
                {
                    users.Add(username, new Dictionary<string, int>());
                }

                if (!users[username].ContainsKey(tag))
                {
                    users[username].Add(tag, likes);
                }

                users[username][tag] = likes;

                input = Console.ReadLine();
            }

            foreach (var user in users.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count))
            {
                Console.WriteLine(user.Key);
                foreach (var tag in user.Value)
                {
                    Console.WriteLine($"- {tag.Key}: {tag.Value}");
                }
            }
        }
    }
}
