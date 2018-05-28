using System;
using System.Collections.Generic;
using System.Linq;

namespace The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(' ').ToList();
            List<string> filtersList = new List<string>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(';');
                if (commands[0] == "Print")
                {
                    break;
                }
                if (commands[0] == "Add filter")
                {
                    filtersList.Add(commands[1] + ";" + commands[2]);

                }
                if (commands[0] == "Remove filter")
                {
                    filtersList.Remove(commands[1] + ";" + commands[2]);
                }

            }

            foreach (var filter in filtersList)
            {
                string[] filterArgs = filter.Split(';');
                string filterAction = filterArgs[0];
                string filterParameter = filterArgs[1];

                if (filterAction == "Starts with")
                {

                    List<string> temp = names.Where(x => x.Substring(0, filterParameter.Length) != filterParameter).ToList();
                    names = temp;
                }
                if (filterAction == "Ends with")
                {
                    List<string> temp = names.Where(x => x.Substring(x.Length - filterParameter.Length, filterParameter.Length) != filterParameter).ToList();
                    names = temp;
                }
                if (filterAction == "Length")
                {
                    List<string> temp = names.Where(x => x.Length.ToString() != filterParameter).ToList();
                    names = temp;
                }
                if (filterAction == "Contains")
                {
                    List<string> temp = names.Where(x => !x.Contains(filterParameter)).ToList();
                    names = temp;
                }
            }
            Console.WriteLine(string.Join(" ", names));
        }
    }
}