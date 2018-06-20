using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Dwarf
    {
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }

        public Dwarf(string name, string hatColor, int physics)
        {
            Name = name;
            HatColor = hatColor;
            Physics = physics;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Dwarf> dwarfs = new List<Dwarf>();
            Dictionary<string, int> hatColors = new Dictionary<string, int>();

            while (input != "Once upon a time")
            {
                string[] dwarfInfo = input.Split(new string[] { " <:> " }, StringSplitOptions.RemoveEmptyEntries);
                string dwarfName = dwarfInfo[0].Trim();
                string dwarfHatColor = dwarfInfo[1].Trim();
                int dwarfPhysics = int.Parse(dwarfInfo[2].Trim());

                if (!hatColors.ContainsKey(dwarfHatColor))
                {
                    hatColors.Add(dwarfHatColor, 1);
                }
                else
                {
                    hatColors[dwarfHatColor]++;
                }

                Dwarf dwarf = new Dwarf(dwarfName, dwarfHatColor, dwarfPhysics);
                if (!dwarfs.Any(x => x.Name == dwarfName && x.HatColor == dwarfHatColor))
                {
                    dwarfs.Add(dwarf);
                }
                else
                {
                    Dwarf existingDwarf = dwarfs.First(x => x.Name == dwarfName && x.HatColor == dwarfHatColor);
                    if (dwarf.Physics > existingDwarf.Physics)
                    {
                        existingDwarf.Physics = dwarf.Physics;
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var dwarf in dwarfs.OrderByDescending(x => x.Physics).ThenByDescending(x => hatColors[x.HatColor]))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }
}