using System;
using System.Collections.Generic;
using System.Linq;

namespace Dragon_Army
{
    class Program
    {
        public class Dragon
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public int Damage { get; set; }
            public int Health { get; set; }
            public int Armor { get; set; }

            public Dragon(string name, string type, int damage, int health, int armor)
            {
                Type = type;
                Name = name;
                Damage = damage;
                Health = health;
                Armor = armor;
            }
        }

        static void Main(string[] args)
        {
            int dragonsCount = int.Parse(Console.ReadLine());
            List<Dragon> dragons = new List<Dragon>();
            HashSet<string> types = new HashSet<string>();

            for (int i = 0; i < dragonsCount; i++)
            {
                string[] dragon = Console.ReadLine().Split(' ').ToArray();
                string type = dragon[0];
                string name = dragon[1];
                int damage = dragon[2] != "null" ? int.Parse(dragon[2]) : 45;
                int health = dragon[3] != "null" ? int.Parse(dragon[3]) : 250;
                int armor = dragon[4] != "null" ? int.Parse(dragon[4]) : 10;

                Dragon existingDragon = dragons.Find(x => x.Name == name && x.Type == type);
                if (existingDragon == null)
                {
                    dragons.Add(new Dragon(name, type, damage, health, armor));
                    types.Add(type);
                }
                else
                {
                    existingDragon.Damage = damage;
                    existingDragon.Health = health;
                    existingDragon.Armor = armor;
                }
            }

            foreach (var type in types)
            {
                var filteredDragons = dragons.Where(x => x.Type == type).OrderBy(x => x.Name);
                double averageDamage = filteredDragons.Average(x => x.Damage);
                double averageHealth = filteredDragons.Average(x => x.Health);
                double averageArmor = filteredDragons.Average(x => x.Armor);

                Console.WriteLine($"{type}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in filteredDragons)
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }
}