using NextailKata.Products;
using System.Collections.Generic;
using System.Linq;

namespace NextailKata.Discounts
{
    public class TwoForOneDiscount : IDiscount
    {
        public string Id { get; }

        public string Description { get; }

        public ProductType ProductType { get; }

        public TwoForOneDiscount(string id, string description, ProductType productType)
        {
            Id = id;
            Description = description;
            ProductType = productType;
        }

        public bool IsDiscountApplyable(List<ProductType> basket)
        {
            return basket.Count(x => x == ProductType) >= 2;
        }

        public decimal ApplyDiscount(List<ProductType> basket)
        {
            var numberOfDiscounts = basket.Count(x => x == ProductType) / 2;

            return numberOfDiscounts * 5;
        }
    }
}
