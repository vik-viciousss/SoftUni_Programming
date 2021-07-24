using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern.Models
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking {typeof(TwelveGrain).Name}");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Gathering ingredients for {typeof(TwelveGrain).Name}");
        }
    }
}
