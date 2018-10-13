using System;
using System.Collections.Generic;

namespace Cubic_Artillery
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();
            int currentCapacityLeft = maxCapacity;

            while (input != "Bunker Revision")
            {
                string[] inputArgs = input.Split();
                foreach (var element in inputArgs)
                {
                    bool isDigit = int.TryParse(element, out int weapon);

                    if (!isDigit)
                    {
                        bunkers.Enqueue(element);
                    }
                    else
                    {
                        bool isWeaponSaved = false;
                        while (bunkers.Count > 1)
                        {
                            if (currentCapacityLeft >= weapon)
                            {
                                weapons.Enqueue(weapon);
                                currentCapacityLeft -= weapon;
                                isWeaponSaved = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Dequeue()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}");
                            }
                            weapons.Clear();
                            currentCapacityLeft = maxCapacity;
                        }

                        if (!isWeaponSaved)
                        {
                            if (weapon <= maxCapacity)
                            {
                                while (currentCapacityLeft < weapon)
                                {
                                    currentCapacityLeft += weapons.Dequeue();
                                }
                                weapons.Enqueue(weapon);
                                currentCapacityLeft -= weapon;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
