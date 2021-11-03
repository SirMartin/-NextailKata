using System.Collections.Generic;

namespace NextailKata
{
    public interface ICheckout
    {
        List<Discount> Discounts { get; }

        void Scan(Item item);
        decimal CalculateTotal();
    }
}