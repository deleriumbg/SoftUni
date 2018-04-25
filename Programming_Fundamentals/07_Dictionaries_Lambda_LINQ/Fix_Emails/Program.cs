using System;
using System.Collections.Generic;
using System.Linq;

namespace Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Dictionary<string, string> emailbook = new Dictionary<string, string>();
            while (name != "stop")
            {
                string email = Console.ReadLine();
                if (emailbook.ContainsKey(name) == false)
                {
                    emailbook.Add(name, email);
                }
                else
                {
                    emailbook[name] = email;
                }
                name = Console.ReadLine();
            }

            foreach (var person in emailbook.Where(x => !x.Value.EndsWith(".us") && !x.Value.EndsWith(".uk")))
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}
