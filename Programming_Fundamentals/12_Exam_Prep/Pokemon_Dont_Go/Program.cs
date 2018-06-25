using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Dont_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int index = int.Parse(Console.ReadLine());
            int totalValue = 0;

            while (pokemons.Count > 0 || index == null)
            {
                int value = 0;
                if (index < 0)
                {
                    value = pokemons[0];
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else
                        {
                            pokemons[i] -= value;
                        }
                    }
                }
                else if (index >= pokemons.Count)
                {
                    value = pokemons[pokemons.Count - 1];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Insert(pokemons.Count, pokemons[0]);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else
                        {
                            pokemons[i] -= value;
                        }
                    }
                }
                else
                {
                    value = pokemons[index];
                    pokemons.RemoveAt(index);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= value)
                        {
                            pokemons[i] += value;
                        }
                        else
                        {
                            pokemons[i] -= value;
                        }
                    }
                }

                totalValue += value;
                try
                {
                    index = int.Parse(Console.ReadLine());
                }
                catch
                {
                    break;
                }
                
            }

            Console.WriteLine(totalValue);
        }
    }
}
