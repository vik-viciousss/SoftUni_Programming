using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefaultGender = "Male";

        private const string DefaultSound = "MEOW";

        public Tomcat(string name, int age) 
            : base(name, age, DefaultGender)
        {
        }

        //optional second ctor
        public Tomcat(string name, int age, string gender)
            : base(name, age, DefaultGender)
        {
        }

        public override string ProduceSound()
        {
            return DefaultSound;
        }
    }
}
