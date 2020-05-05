using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(new []{", "},StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> songs = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, HashSet<string>> awards = new Dictionary<string, HashSet<string>>();
            string input = Console.ReadLine();

            while (input != "dawn")
            {
                string[] singerInfo = input.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                string singer = singerInfo[0];
                string song = singerInfo[1];
                string award = singerInfo[2];
                if (participants.Contains(singer) && songs.Contains(song))
                {
                    if (!awards.ContainsKey(singer))
                    {
                        awards.Add(singer, new HashSet<string>());
                        awards[singer].Add(award);
                    }
                    else
                    {
                        awards[singer].Add(award);
                    }
                }
                input = Console.ReadLine();
            }

            if (awards.Count > 0)
            {
                foreach (var singer in awards.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{singer.Key}: {singer.Value.Count} awards");
                    foreach (var award in singer.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}
