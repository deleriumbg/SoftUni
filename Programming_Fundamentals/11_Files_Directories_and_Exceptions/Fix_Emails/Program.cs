using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fix_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("Input.txt");
            Dictionary<string, string> emailbook = new Dictionary<string, string>();
            File.Delete("Output.txt");
            for (int i = 0; i < text.Length - 1; i += 2)
            {
                string name = text[i];
                string email = text[i + 1];
                if (name == "stop" || email == "stop")
                {
                    break;
                }
                else if (emailbook.ContainsKey(name) == false)
                {
                    emailbook.Add(name, email);
                }
                else
                {
                    emailbook[name] = email;
                }
            }
            foreach (var person in emailbook.Where(x => !x.Value.EndsWith(".us") && !x.Value.EndsWith(".uk")))
            {
                string result = $"{person.Key} -> {person.Value}";
                File.AppendAllText("Output.txt", result + Environment.NewLine);
            }
        }
    }
}
