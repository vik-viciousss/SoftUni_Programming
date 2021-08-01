using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int lapsMinValue = 1;

        private const int nameMinValue = 5;

        private string name;
        private int laps;
        private readonly IDictionary<string, IDriver> driversByName;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.driversByName = new Dictionary<string, IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < nameMinValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, nameMinValue));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < lapsMinValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, lapsMinValue));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.driversByName.Values.ToList();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverInvalid));
            }
            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }
            if (driversByName.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.driversByName[driver.Name] = driver;
        }
    }
}
