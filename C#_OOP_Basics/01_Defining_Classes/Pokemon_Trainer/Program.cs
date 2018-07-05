using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();

        string input = Console.ReadLine();
        while (input != "Tournament")
        {
            string[] pokemonInfo = input.Split();
            string trainerName = pokemonInfo[0];
            string pokemonName = pokemonInfo[1];
            string pokemonElement = pokemonInfo[2];
            double pokemonHealth = double.Parse(pokemonInfo[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            if (trainers.All(x => x.Name != trainerName))
            {
                Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>());
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }
            else
            {
                Trainer existingTrainer = trainers.First(x => x.Name == trainerName);
                existingTrainer.Pokemons.Add(pokemon);
            }
            input = Console.ReadLine();
        }

        string element = Console.ReadLine();
        while (element != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == element))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.ForEach(x => x.Health -= 10);
                    if (trainer.Pokemons.Any(x => x.Health <= 0))
                    {
                        var deadPokemons = trainer.Pokemons.FindAll(x => x.Health <= 0).ToList();
                        trainer.Pokemons = trainer.Pokemons.Except(deadPokemons).ToList();
                    }
                }
            }
            element = Console.ReadLine();
        }

        foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }
    }
}
