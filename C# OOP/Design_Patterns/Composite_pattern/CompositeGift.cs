using System;
using System.Collections.Generic;
using System.Text;

namespace Composite_pattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, decimal price) 
            : base(name, price)
        {
            this.gifts = new HashSet<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public override decimal CalculatePrice()
        {
            decimal total = 0;

            Console.Write($"Gift {this.name} contains products for: ");

            foreach (var gift in this.gifts)
            {
                total += gift.CalculatePrice();
            }

            Console.WriteLine($"{total}");

            return total;
        }

        public void Remove(GiftBase gift)
        {
            this.gifts.Remove(gift);
        }
    }
}
