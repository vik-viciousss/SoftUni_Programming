using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern.Models
{
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the whole wheat bread ..");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for the whole wheat bread..");
        }
    }
}
