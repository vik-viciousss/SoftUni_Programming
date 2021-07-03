using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator_02
{
    public class Player
    {
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
                if (String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty.");
                    return;
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"{nameof(this.Endurance)} should be between 0 and 100.");
                    return;
                }

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"{nameof(this.Sprint)} should be between 0 and 100.");
                    return;
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"{nameof(this.Dribble)} should be between 0 and 100.");
                    return;
                }

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"{nameof(this.Passing)} should be between 0 and 100.");
                    return;
                }

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"{nameof(this.Shooting)} should be between 0 and 100.");
                    return;
                }

                this.shooting = value;
            }
        }

        public double AverageSkillPoints => Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
    }
}
