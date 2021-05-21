using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name 
        { 
            get => this.name; 
            private set
            {
                Validator.ThrowIfStringIsNullOrWhitespace(value, GlobalConstants.InvalidNameExceptionErrorMessage);

                this.name = value;
            } 
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStatValue, MaxStatValue, 
                    $"{nameof(this.Endurance)} should be between {MinStatValue} and {MaxStatValue}.");

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStatValue, MaxStatValue,
                    $"{nameof(this.Sprint)} should be between {MinStatValue} and {MaxStatValue}.");

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStatValue, MaxStatValue,
                    $"{nameof(this.Dribble)} should be between {MinStatValue} and {MaxStatValue}.");

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStatValue, MaxStatValue,
                    $"{nameof(this.Passing)} should be between {MinStatValue} and {MaxStatValue}.");

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(value, MinStatValue, MaxStatValue,
                    $"{nameof(this.Shooting)} should be between {MinStatValue} and {MaxStatValue}.");

                this.shooting = value;
            }
        }

        public double AverageSkillPoints => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
    }
}
