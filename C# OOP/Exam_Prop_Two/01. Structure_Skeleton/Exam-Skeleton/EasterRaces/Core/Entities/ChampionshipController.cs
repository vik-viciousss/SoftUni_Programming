using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int raceMinParticipants = 3;

        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carsRepository;
        private readonly IRepository<IRace> racesRepository;

        //keep one empty!!!
        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carsRepository = new CarRepository();
            this.racesRepository = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }
        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carsRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            type = type + "Car";

            //ICar car = (Car)Activator.CreateInstance(type.GetType());

            ICar car = null;
            switch (type)
            {
                case nameof(MuscleCar):
                    car = new MuscleCar(model, horsePower);
                    break;
                case nameof(SportsCar):
                    car = new SportsCar(model, horsePower);
                    break;
            }

            this.carsRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }
            if (this.carsRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            var driver = this.driverRepository.GetByName(driverName);
            var car = this.carsRepository.GetByName(carModel);
            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.racesRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (this.driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var race = this.racesRepository.GetByName(raceName);
            var driver = this.driverRepository.GetByName(driverName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.racesRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.racesRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.racesRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < raceMinParticipants)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, raceMinParticipants));
            }

            List<IDriver> topThree = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();
            this.racesRepository.Remove(race);

            IDriver driverOne = topThree[0];
            IDriver driverTwo = topThree[1];
            IDriver driverThree = topThree[2];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, driverOne.Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, driverTwo.Name, raceName));
            sb.Append(string.Format(OutputMessages.DriverThirdPosition, driverThree.Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}
