using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = Console.ReadLine();
            string[] animalInfo = Console.ReadLine().Split();
            List<Animal> animals = new List<Animal>();

            while (animalType != "Beast!")
            {
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                if (string.IsNullOrEmpty(name) || age < 0 || string.IsNullOrEmpty(gender))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (animalType == "Dog")
                {
                    var dog = new Dog(name, age, gender);
                    animals.Add(dog);
                }
                else if (animalType == "Frog")
                {
                    var frog = new Frog(name, age, gender);
                    animals.Add(frog);
                }
                else if (animalType == "Cat")
                {
                    var cat = new Cat(name, age, gender);
                    animals.Add(cat);
                }
                else if (animalType == "Kitten")
                {
                    var kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                else if (animalType == "Tomcat")
                {
                    var tomcat = new Tomcat(name, age);
                    animals.Add(tomcat);
                }

                animalType = Console.ReadLine();
                animalInfo = Console.ReadLine().Split();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
