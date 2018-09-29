using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vlogger = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] vloggerInput = input.Split();
                string vloggerName = vloggerInput[0];
                string action = vloggerInput[1];
                string followedVlogger = vloggerInput[2];

                switch (action)
                {
                    case "joined":
                        if (!vlogger.ContainsKey(vloggerName))
                        {
                            vlogger.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                            vlogger[vloggerName].Add("following", new SortedSet<string>());
                            vlogger[vloggerName].Add("followers", new SortedSet<string>());
                        }
                        break;
                    case "followed":
                        if (vloggerName != followedVlogger && vlogger.ContainsKey(vloggerName))
                        {
                            if (vlogger.ContainsKey(followedVlogger))
                            {
                                vlogger[vloggerName]["following"].Add(followedVlogger);
                                vlogger[followedVlogger]["followers"].Add(vloggerName);
                            }
                        }
                        break;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vlogger.Count} vloggers in its logs.");

            int counter = 1;
            foreach (var person in vlogger.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{counter}. {person.Key} : {person.Value["followers"].Count} followers, {person.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var follower in person.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                counter++;
            }
        }
    }
}
