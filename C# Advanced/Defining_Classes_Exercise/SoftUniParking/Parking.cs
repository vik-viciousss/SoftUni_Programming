using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {

        private List<Car> cars;

        private int capacity;

        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {

            if (this.cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.cars.Count == this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

            if (car == null)
            {
                return $"Car with that registration number, doesn't exist!";
            }

            this.cars.Remove(car);
            return $"Successfully removed {registrationNumber}";


            //if (!this.cars.Any(c => c.RegistrationNumber == registrationNumber))
            //{
            //    return $"Car with that registration number, doesn't exist!";
            //}

            //int index = this.cars.FindIndex(c => c.RegistrationNumber == registrationNumber);
            //this.cars.RemoveAt(index);
            //return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            //foreach (var number in registrationNumbers)
            //{
            //    if (this.cars.Any(c => c.RegistrationNumber))
            //    {
            //        this.cars.RomoveCar();
            //    }


            //}


            this.cars = this.cars.Where(c => !registrationNumbers.Contains(c.RegistrationNumber)).ToList();

            //foreach (var carNumber in registrationNumbers)
            //{
            //    if (this.cars.Any(c => c.RegistrationNumber == carNumber))
            //    {
            //        int index = this.cars.FindIndex(c => c.RegistrationNumber == carNumber);
            //        this.cars.RemoveAt(index);
            //    }
            //}
        }
    }
}
