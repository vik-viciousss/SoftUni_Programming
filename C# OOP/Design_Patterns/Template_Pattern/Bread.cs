﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Template_Pattern
{
    public abstract class Bread
    {
        public abstract void MixIngredients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine("Slicing..");
        }

        void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}
