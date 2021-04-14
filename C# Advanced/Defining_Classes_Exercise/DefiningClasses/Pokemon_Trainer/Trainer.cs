using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer(string trainerName)
        {
            this.Name = trainerName;
            this.NumberOfBadges = 0;
            this.CollectionOfPokemon = new List<Pokemon>();
        }
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> CollectionOfPokemon { get; set; }
    }
}
