using System.Collections.Generic;

namespace NextailKata
{
    public class Checkout : ICheckout
    {
        public Checkout(List<Discount> discounts)
        {
            Discounts = discounts;
            BoughtItems = new List<Item>();
        }

        public List<Discount> Discounts { get; }

        public List<Item> BoughtItems { get; }

        public void Scan(Item item)
        {
            BoughtItems.Add(item);
        }

        public decimal CalculateTotal()
        {
            return BoughtItems.Sum(x => x.Price);
        }
    }
}
