using System;
using System.Collections.Generic;
using System.Linq;

namespace Pokemon_Trainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputData = Console.ReadLine().Split();

            List<Trainer> trainersList = new List<Trainer>();

            while (inputData[0] != "Tournament")
            {
                string trainerName = inputData[0];
                string pokemonName = inputData[1];
                string element = inputData[2];
                int health = int.Parse(inputData[3]);

                Trainer currTrainer = new Trainer(trainerName);
                Pokemon currPokemon = new Pokemon(pokemonName, element, health);

                int index = trainersList.FindIndex(t => t.Name == trainerName);
                
                if (index >= 0)
                {
                    trainersList[index].CollectionOfPokemon.Add(currPokemon);
                }
                else
                {
                    currTrainer.CollectionOfPokemon.Add(currPokemon);
                    trainersList.Add(currTrainer); 
                }

                inputData = Console.ReadLine().Split();
            }

            string command = Console.ReadLine();
            bool hasPokemon = false;

            while (command != "End")
            {
                foreach (var trainer in trainersList)
                {
                    foreach (var pokemon in trainer.CollectionOfPokemon)
                    {
                        if (pokemon.Element == command)
                        {
                            trainer.NumberOfBadges++;
                            hasPokemon = true;
                            break;
                        }
                    }

                    if (!hasPokemon)
                    {
                        foreach (var pokemon in trainer.CollectionOfPokemon)
                        {
                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                trainer.CollectionOfPokemon.Remove(pokemon);

                                if (trainer.CollectionOfPokemon.Count == 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    
                    hasPokemon = false;
                }
                
                command = Console.ReadLine();
            }

            List<Trainer> sortedList = trainersList.OrderByDescending(t => t.NumberOfBadges).ToList();

            foreach (var trainer in sortedList)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemon.Count}");
            }
        }
    }
}
