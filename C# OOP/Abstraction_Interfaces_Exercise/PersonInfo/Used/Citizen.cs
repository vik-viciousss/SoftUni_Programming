using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Used
{
    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food => throw new NotImplementedException();

        public void BuyFood()
        {
            throw new NotImplementedException();
        }
    }
}
