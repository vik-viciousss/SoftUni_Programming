using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Used
{
    public class Pet : IPet
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Birthdate { get; private set; }

        public int Age => throw new NotImplementedException();

        public int Food => throw new NotImplementedException();

        public void BuyFood()
        {
            throw new NotImplementedException();
        }
    }
}
