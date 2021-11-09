using NextailKata.Products;
using System.Collections.Generic;

namespace NextailKata.Discounts
{
    public interface IDiscount
    {
        string Id { get; }

        string Description { get; }

        bool IsDiscountApplicable(List<ProductType> basket);

        decimal ApplyDiscount(List<ProductType> basket);
    }
}