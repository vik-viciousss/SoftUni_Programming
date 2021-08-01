using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitCar car;
        private UnitDriver driver;
        private const string DriverAdded = "Driver {0} added in race.";
        private const int MinParticipants = 2;

        [SetUp]
        public void Setup()
        {
            race = new RaceEntry();
            car = new UnitCar("model", 200, 100.7);
            driver = new UnitDriver("name", car);
        }

        [Test]
        public void When_TryAddNullDriver_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(null);
            });
        }

        [Test]
        public void When_TryAddExistingDriver_ShouldThrow()
        {
            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.AddDriver(driver);
            });
        }

        [Test]
        public void When_AddValidDriver_ShouldIncrCounter()
        {
            race.AddDriver(driver);

            Assert.That(race.Counter, Is.EqualTo(1));
        }

        [Test]
        public void When_AddedDriver_ShouldReturnString()
        {
            Assert.AreEqual(race.AddDriver(driver), string.Format(DriverAdded, driver.Name));
        }

        [Test]
        public void When_RaceDoesntHaveEnoughPart_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });

            race.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                race.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void When_CalculateIsCalled_ShouldReturnResult()
        {
            double expected = 0;

            for (int i = 0; i < 10; i++)
            {
                int hp = 450 + i;
                expected += hp;
                race.AddDriver(new UnitDriver($"name{i}", new UnitCar($"{i}name", hp, 450)));
            }

            expected /= 10;

            Assert.AreEqual(expected, race.CalculateAverageHorsePower());
        }
        
    }
}