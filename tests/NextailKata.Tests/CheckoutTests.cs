using NUnit.Framework;
using System.Collections.Generic;

namespace NextailKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        public Checkout Checkout { get; set; }

        [OneTimeSetUp]
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

            Checkout = new Checkout(discounts);
        }

        [TestCase]
        public void Checkout_OneOfEachProductTotal_SuccessPrice()
        {
            var items = new List<Item> {
                new Item {
                    Id = "VOUCHER",
                    Name = "Gift Card",
                    Price = 5
                },
                new Item {
                    Id = "TSHIRT",
                    Name = "Summer T-Shirt",
                    Price = 20
                },
                new Item {
                    Id = "PANTS",
                    Name = "Summer Pants",
                    Price = 7.5M
                }
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(32.50M, totalPrice); ;
        }
    }
}
