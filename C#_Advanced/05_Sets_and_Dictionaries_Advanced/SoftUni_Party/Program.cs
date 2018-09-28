using System;
using System.Collections.Generic;

namespace SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string guestInput = Console.ReadLine();
            HashSet<string> vip = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            while (guestInput != "PARTY")
            {
                if (char.IsDigit(guestInput[0]))
                {
                    vip.Add(guestInput);
                }
                else
                {
                    regular.Add(guestInput);
                }

                guestInput = Console.ReadLine();
            }

            string arrivingGuest = Console.ReadLine();

            while (arrivingGuest != "END")
            {
                if (vip.Contains(arrivingGuest))
                {
                    vip.Remove(arrivingGuest);
                }
                if (regular.Contains(arrivingGuest))
                {
                    regular.Remove(arrivingGuest);
                }

                arrivingGuest = Console.ReadLine();
            }

            Console.WriteLine(vip.Count + regular.Count);
            foreach (var guest in vip)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regular)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
