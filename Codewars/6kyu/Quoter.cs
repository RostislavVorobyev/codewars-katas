using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars
{
    public class Quoter
    {
        private List<Item> Items { get; set; }

        public Quoter(List<Item> items)
        {
            Items = items;
        }

        public string GetQuote(int quantity)
        {
            var pricelist = new List<decimal>();
            Items.OrderByDescending(c => c.UnitMargin).All(i => { pricelist.AddRange(Enumerable.Repeat(i.UnitPrice, i.Quantity)); return true; });
            return pricelist.Count >= quantity ? string.Format("Your best quote for {0} items is {1}", quantity, pricelist.Take(quantity).Sum().ToString("#.00")) :
            "Your order cannot be fulfilled, try lower quantity";

            var orderedByMargin = Items.OrderByDescending(x => x.UnitMargin).ToArray();
            decimal totalPrice = 0;
            var itemsLeft = quantity;

            for (var i = 0; i < Items.Count; i++)
            {
                var incr = Math.Min(orderedByMargin[i].Quantity, itemsLeft);

                totalPrice += incr * orderedByMargin[i].UnitPrice;
                itemsLeft -= incr;

                if (itemsLeft == 0)
                {
                    return $"Your best quote for {quantity} items is {totalPrice:0.00}";
                }
            }

            return "Your order cannot be fulfilled, try lower quantity";
        }
    }

    public class Item
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitMargin { get; set; }
    }
}
