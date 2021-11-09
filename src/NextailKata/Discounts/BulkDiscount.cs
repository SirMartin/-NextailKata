using NextailKata.Products;
using System.Collections.Generic;
using System.Linq;

namespace NextailKata.Discounts
{
    public class BulkDiscount : IDiscount
    {
        public string Id { get; }

        public string Description { get; }

        public ProductType ProductType { get; }

        public int MinQuantity { get; }

        public decimal PriceDifference { get; }

        public BulkDiscount(string id, string description, ProductType productType, int minQuantity, decimal priceDifference)
        {
            Id = id;
            Description = description;
            ProductType = productType;
            MinQuantity = minQuantity;
            PriceDifference = priceDifference;
        }

        public bool IsDiscountApplicable(List<ProductType> basket)
        {
            return basket.Count(x => x == ProductType) >= MinQuantity;
        }

        public decimal ApplyDiscount(List<ProductType> basket)
        {
            var numberOfItems = basket.Count(x => x == ProductType);

            return numberOfItems * PriceDifference;
        }
    }
}
