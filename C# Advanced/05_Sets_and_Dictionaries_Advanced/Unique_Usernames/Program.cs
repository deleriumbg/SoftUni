using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int usernamesCount = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < usernamesCount; i++)
            {
                usernames.Add(Console.ReadLine());
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
