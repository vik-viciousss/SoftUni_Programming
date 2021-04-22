using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count 
        {
            get { return this.data.Count; }
        }

        public void Add(Pet pet)
        {
            if (this.Capacity > data.Count)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            //foreach (var pet in data)
            //{
            //    if (pet.Name == name)
            //    {
            //        data.Remove(pet);
            //        return true;
            //    }
            //}

            //return false;

            Pet pet = this.data.FirstOrDefault(p => p.Name == name);

            if (pet == null)
            {
                return false;
            }

            this.data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name, string owner)
        {
            //foreach (var pet in data)
            //{
            //    if (pet.Name == name && pet.Owner == owner)
            //    {
            //        return pet;
            //    }
            //}

            //return null;

            Pet pet = this.data.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            //Pet oldestPet = new Pet("", 0, "");

            //foreach (var pet in data)
            //{
            //    if (pet.Age > oldestPet.Age)
            //    {
            //        oldestPet = pet;
            //    }
            //}

            //return oldestPet;

            return this.data.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            if (this.data.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("The clinic has the following patients:");

                foreach (var pet in data)
                {
                    sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
                }

                return sb.ToString();
            }

            return null;
        }
    }
}
