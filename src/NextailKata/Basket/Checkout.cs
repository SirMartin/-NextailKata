using NextailKata.Discounts;
using NextailKata.Products;
using System.Collections.Generic;
using System.Linq;

namespace NextailKata.Basket
{
    public class Checkout : ICheckout
    {
        public Checkout(List<IDiscount> discounts, List<Product> products)
        {
            Discounts = discounts;
            Products = products;
            BoughtItems = new List<ProductType>();
        }

        public List<IDiscount> Discounts { get; }

        public List<Product> Products { get; }

        public List<ProductType> BoughtItems { get; }

        public void Scan(ProductType product)
        {
            BoughtItems.Add(product);
        }

        public decimal CalculateTotal()
        {
            var totalPrice = BoughtItems.Sum(i => Products.Single(p => p.Id == i).Price);

            totalPrice = ApplyDiscounts(totalPrice);

            return totalPrice;
        }

        private decimal ApplyDiscounts(decimal totalPrice)
        {
            // Check for the different discounts if can be applied.
            foreach(var discount in Discounts)
            {
                if (discount.IsDiscountApplyable(BoughtItems))
                {
                    totalPrice -= discount.ApplyDiscount(BoughtItems);
                }
            }

            return totalPrice;
        }

    }
}
