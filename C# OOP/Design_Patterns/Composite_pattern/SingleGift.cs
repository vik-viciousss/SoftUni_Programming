using System;
using System.Collections.Generic;
using System.Text;

namespace Composite_pattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override decimal CalculatePrice()
        {
            return this.price;
        }
    }
}
