using NUnit.Framework;
using System.Collections.Generic;

namespace NextailKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        public Checkout Checkout { get; set; }

        [SetUp]
        public void Setup()
        {
            var discounts = new List<Discount>
            {
                new Discount {
                    Id = "2x1_Vouchers",
                    Description = "A 2-for-1 special on VOUCHER items."
                },
                new Discount {
                    Id = "TShirtsBulk",
                    Description = "If you buy 3 or more TSHIRT items, the price per unit should be 19.00€."
                }
            };

            var products = new List<Product>
            {
                new Product {
                    Id = ProductType.VOUCHER,
                    Name = "Gift Card",
                    Price = 5M
                },
                new Product {
                    Id = ProductType.TSHIRT,
                    Name = "Summer T-Shirt",
                    Price = 20M
                },
                new Product {
                    Id = ProductType.PANTS,
                    Name = "Summer Pants",
                    Price = 7.5M
                }
            };

            Checkout = new Checkout(discounts, products);
        }

        [TestCase]
        public void CalculateTotal_OneOfEachProductTotal_SuccessPrice()
        {
            var items = new List<ProductType> {
                ProductType.VOUCHER,
                ProductType.TSHIRT,
                ProductType.PANTS
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(32.50M, totalPrice); ;
        }

        [TestCase]
        public void CalculateTotal_SameItemMultiplyTimesTotal_SuccessPrice()
        {
            var items = new List<ProductType> {
                ProductType.PANTS,
                ProductType.PANTS,
                ProductType.PANTS
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(22.5M, totalPrice); ;
        }

        [TestCase]
        public void CalculateTotal_MultipleItemsMultiplyTimesTotal_SuccessPrice()
        {
            var items = new List<ProductType> {
                ProductType.TSHIRT,
                ProductType.TSHIRT,
                ProductType.PANTS,
                ProductType.PANTS,
                ProductType.PANTS
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(62.5M, totalPrice); ;
        }

    }
}
