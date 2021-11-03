using System.Collections.Generic;

namespace NextailKata
{
    public class Checkout : ICheckout
    {
        public Checkout(List<Discount> discounts)
        {
            Discounts = discounts;
        }

        public List<Discount> Discounts { get; }

        public void Scan(Item item)
        {
            
        }

        public decimal CalculateTotal()
        {
            return 0;
        }
    }
}
