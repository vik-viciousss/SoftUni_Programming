using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    public class SandwichMenu
    {
        private readonly Dictionary<string, SandwitchPrototype> sandwiches;

        public SandwichMenu()
        {
            this.sandwiches = new Dictionary<string, SandwitchPrototype>();
        }

        public SandwitchPrototype this[string name]
        {
            get
            {
                return this.sandwiches[name];
            }
            set
            {
                this.sandwiches[name] = value;
            }
        }

    }
}
