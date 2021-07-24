using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern.Models
{
    public class SourDough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the sourdough bread.. (20 mins)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Mixing the sourdough dough :P");
        }
    }
}
