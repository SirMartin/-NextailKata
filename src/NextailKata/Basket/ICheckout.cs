using NextailKata.Discounts;
using NextailKata.Products;
using System.Collections.Generic;

namespace NextailKata.Basket
{
    public interface ICheckout
    {
        List<IDiscount> Discounts { get; }

        List<Product> Products { get; }

        void Scan(ProductType product);
        decimal CalculateTotal();
    }
}