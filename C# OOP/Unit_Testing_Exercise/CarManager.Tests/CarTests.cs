using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private string make = "make";
        private string model = "model";
        private double fuelConsuption = 10.0;
        private double fuelCapacity = 100.0;
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(make, model, fuelConsuption, fuelCapacity);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, -10)]
        [TestCase("Make", "Model", 10, 0)]
        public void When_CtorIsCalledWithInvalidData_ShouldThrowArgumentEx(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void When_CtorIsCalledWithValidArgs_ShouldSetInitialValues()
        {
            string make = "make";
            string model = "model";
            double fuelConsuption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsuption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsuption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void When_RefuelIsCalledWithZeroOrNegative_ShouldThrowArgumentEx(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelToRefuel));
        }

        [Test]
        public void When_RefuelIsCalledWithValidData_ShouldIncreaseFuelAmountWithValue()
        {
            double fuelToRefuel = this.car.FuelCapacity / 2;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, this.car.FuelAmount);
        }

        [Test]
        public void When_RefuelWithMoreThanCapacity_ShouldSetValueToCapacity()
        {
            double fuelToRefuel = this.car.FuelCapacity * 2;

            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(this.car.FuelAmount, this.car.FuelCapacity);
        }

        [Test]
        public void When_DriveIsCalledWithEmptyTank_ShouldThrowInvalidOperation()
        {
            double distance = 100;

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(distance));
        }

        [Test]
        public void When_DriveIsCalledWithValidDistance_ShouldDecreaseFuelAmount()
        {
            double initialFuel = this.car.FuelCapacity;

            this.car.Refuel(initialFuel);
            this.car.Drive(10);

            Assert.That(this.car.FuelAmount, Is.LessThan(initialFuel));
        }

    }
}