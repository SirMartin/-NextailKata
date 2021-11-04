using NextailKata.Discounts;
using NextailKata.Products;
using System.Collections.Generic;

namespace NextailKata.Checkout
{
    public interface ICheckout
    {
        List<IDiscount> Discounts { get; }

        List<Product> Products { get; }

        void Scan(ProductType product);

        decimal CalculateTotal();
    }
}