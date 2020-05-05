using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Evolution
{
    class Pokemon
    {
        public string Name { get; set; }

        // Using Tuple instead of Dictionary, because a single pokemon may have many evolutions with the same type and the same index.
        public List<Tuple<string, int>> EvolutionTypeAndIndex { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Pokemon> pokemons = new List<Pokemon>();

            while (input != "wubbalubbadubdub")
            {
                string[] pokemonInfo = input.Split(new[] {'-', '>', ' '}, StringSplitOptions.RemoveEmptyEntries);
                if (pokemonInfo.Length == 3)
                {
                    string pokemonName = pokemonInfo[0];
                    string evolutionType = pokemonInfo[1];
                    int evolutionIndex = int.Parse(pokemonInfo[2]);

                    Pokemon pokemon = new Pokemon();
                    if (pokemons.All(x => x.Name != pokemonName))
                    {
                        pokemon.Name = pokemonName;
                        pokemon.EvolutionTypeAndIndex = new List<Tuple<string, int>>();
                        pokemon.EvolutionTypeAndIndex.Add(new Tuple<string, int>(evolutionType, evolutionIndex));
                        pokemons.Add(pokemon);
                    }
                    else
                    {
                        Pokemon existingPokemon = pokemons.First(x => x.Name == pokemonName);
                        existingPokemon.EvolutionTypeAndIndex.Add(new Tuple<string, int>(evolutionType, evolutionIndex));
                    }
                }
                else if (pokemonInfo.Length == 1)
                {
                    string pokemonName = pokemonInfo[0];
                    if (pokemons.Any(x => x.Name == pokemonName))
                    {
                        Pokemon currentPokemon = pokemons.First(x => x.Name == pokemonName);
                        Console.WriteLine($"# {currentPokemon.Name}");
                        foreach (var typeIndexPair in currentPokemon.EvolutionTypeAndIndex)
                        {
                            Console.WriteLine($"{typeIndexPair.Item1} <-> {typeIndexPair.Item2}");
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Name}");
                foreach (var typeIndexPair in pokemon.EvolutionTypeAndIndex.OrderByDescending(x => x.Item2))
                {
                    Console.WriteLine($"{typeIndexPair.Item1} <-> {typeIndexPair.Item2}");
                }
            }
        }
    }
}
