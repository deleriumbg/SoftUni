using System;
using System.Collections.Generic;
using System.Linq;

namespace Logs_Aggregator
{
    class Program
    {
        public class User
        {
            public string Name { get; set; }
            public HashSet<string> IPs { get; set; }
            public int Duration { get; set; }
        }

        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            List<User> users = new List<User>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string ip = input[0];
                string userName = input[1];
                int duration = int.Parse(input[2]);

                User user = new User();
                if (!users.Any(x => x.Name == userName))
                {
                    user.Name = userName;
                    user.IPs = new HashSet<string>();
                    user.IPs.Add(ip);
                    user.Duration += duration;
                }
                else
                {
                    user = users.Find(x => x.Name == userName);
                    user.IPs.Add(ip);
                    user.Duration += duration;
                }
                users.Add(user);
            }

            foreach (var user in users.Distinct().OrderBy(x => x.Name))
            {
                Console.WriteLine($"{user.Name}: {user.Duration} [{string.Join(", ", user.IPs.OrderBy(x => x))}]"); 
            }
        }
    }
}
