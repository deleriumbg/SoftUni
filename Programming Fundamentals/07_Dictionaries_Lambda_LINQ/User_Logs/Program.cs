using System;
using System.Collections.Generic;
using System.Linq;

namespace User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> log = new Dictionary<string, Dictionary<string, int>>();
            List<string> input = Console.ReadLine().Split(' ').ToList();
            string userName = "";
            string ipAddress = "";

            while (input[0] != "end")
            {
                List<string> ip = input[0].Split('=').ToList();
                List<string> user = input[2].Split('=').ToList();
                Dictionary<string, int> messageCount = new Dictionary<string, int>();
                ipAddress = ip[1];
                userName = user[1];
                if (log.ContainsKey(userName) == false)
                {
                    messageCount.Add(ipAddress, 1);
                    log.Add(userName, messageCount);
                }
                else
                {
                    if (log[userName].ContainsKey(ipAddress) == false)
                    {
                        log[userName].Add(ipAddress, 1);
                    }
                    else
                    {
                        log[userName][ipAddress]++;
                    }
                }
                input = Console.ReadLine().Split(' ').ToList();

            }
            foreach (var users in log.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{users.Key}: ");
                List<string> temp = new List<string>();
                foreach (var ips in users.Value)
                {
                    temp.Add($"{ips.Key} => {ips.Value}");
                }
                Console.WriteLine(string.Join(", ", temp) + ".");
            }
        }
    }
}
