using System.Collections.Generic;

namespace NextailKata
{
    public interface ICheckout
    {
        List<Discount> Discounts { get; }

        List<Product> Products { get; }

        void Scan(ProductType product);
        decimal CalculateTotal();
    }
}