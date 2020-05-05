using System;

namespace Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maxHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            string health = '|' + new string('|', currentHealth) + new string('.', maxHealth - currentHealth) + '|';
            string energy = '|' + new string('|', currentEnergy) + new string('.', maxEnergy - currentEnergy) + '|';
            Console.WriteLine($"Name: {name}\r\nHealth: {health}\r\nEnergy: {energy}");
        }
    }
}
