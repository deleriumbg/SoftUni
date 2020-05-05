using System;
using System.Collections.Generic;
using System.Linq;

namespace Roli_The_Coder
{
    class Event
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public HashSet<string> Participants { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Event> events = new List<Event>();

            while (input != "Time for Code")
            {
                string[] eventInfo = input.Split(new [] { ' ' },StringSplitOptions.RemoveEmptyEntries);
                if (eventInfo.Length < 2)
                {
                    input = Console.ReadLine();
                    continue;
                }
                Event currentEvent = new Event();
                currentEvent.ID = eventInfo[0].Trim();
                if (!eventInfo[1].Trim().StartsWith("#"))
                {
                    input = Console.ReadLine();
                    continue;
                }

                currentEvent.Name = eventInfo[1].Trim().TrimStart('#');
                HashSet<string> currentParticipants = new HashSet<string>();
                currentParticipants.UnionWith(eventInfo.Skip(2));
                currentEvent.Participants = currentParticipants;

                if (events.All(x => x.ID != currentEvent.ID))
                {
                    events.Add(currentEvent);
                }
                else
                {
                    if (events.Any(x => x.ID == currentEvent.ID && events.All(y => y.Name != currentEvent.Name)))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                    else if (events.Any(x => x.ID == currentEvent.ID && x.Name == currentEvent.Name))
                    {
                        Event existingEvent = events.First(x => x.ID == currentEvent.ID && x.Name == currentEvent.Name);
                        existingEvent.Participants.UnionWith(currentEvent.Participants);
                    }
                }

                
                input = Console.ReadLine();
            }

            foreach (var eventName in events.OrderByDescending(x => x.Participants.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{eventName.Name} - {eventName.Participants.Count}");
                foreach (var participant in eventName.Participants.OrderBy(x => x))
                {
                    Console.WriteLine($"{participant}");
                }
            }
        }
    }
}
