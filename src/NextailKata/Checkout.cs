using System.Collections.Generic;
using System.Linq;

namespace NextailKata
{
    public class Checkout : ICheckout
    {
        public Checkout(List<Discount> discounts, List<Product> products)
        {
            Discounts = discounts;
            Products = products;
            BoughtItems = new List<ProductType>();
        }

        public List<Discount> Discounts { get; }

        public List<Product> Products { get; }

        public List<ProductType> BoughtItems { get; }

        public void Scan(ProductType product)
        {
            BoughtItems.Add(product);
        }

        public decimal CalculateTotal()
        {
            return BoughtItems.Sum(i => Products.Single(p => p.Id == i).Price);
        }
    }
}
