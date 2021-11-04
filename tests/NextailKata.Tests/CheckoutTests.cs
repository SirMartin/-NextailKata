using NextailKata.Discounts;
using NextailKata.Products;
using NUnit.Framework;
using System.Collections.Generic;

namespace NextailKata.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        public Checkout.Checkout Checkout { get; set; }

        [SetUp]
        public void Setup()
        {
            var discounts = new List<IDiscount>
            {
                new TwoForOneDiscount("2x1_Vouchers", "A 2-for-1 special on VOUCHER items.", ProductType.VOUCHER),
                new BulkDiscount ("TShirtsBulk", "If you buy 3 or more TSHIRT items, the price per unit should be 19.00€.", ProductType.TSHIRT, 3, 1)
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

            Checkout = new Checkout.Checkout(discounts, products);
        }

        [TestCase]
        public void CalculateTotal_OnlyVoucher_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.VOUCHER
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(5M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_OnlyTShirt_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.TSHIRT
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(20M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_OnlyPants_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.PANTS
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(7.50M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_OneOfEachProduct_CorrectPrice()
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

            Assert.AreEqual(32.50M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_SameItemMultiplyTimes_CorrectPrice()
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

            Assert.AreEqual(22.5M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_MultipleItemsMultiplyTimes_CorrectPrice()
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

            Assert.AreEqual(62.5M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_VoucherDiscount_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.VOUCHER,
                ProductType.TSHIRT,
                ProductType.VOUCHER
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(25M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_MultipleVoucherDiscount_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(15M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_MultipleVoucherDiscountWithExtraVouchers_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.VOUCHER
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(20M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_TShirtDiscount_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.TSHIRT,
                ProductType.TSHIRT,
                ProductType.TSHIRT,
                ProductType.VOUCHER,
                ProductType.TSHIRT
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(81M, totalPrice);
        }

        [TestCase]
        public void CalculateTotal_MultipleDiscounts_CorrectPrice()
        {
            var items = new List<ProductType> {
                ProductType.VOUCHER,
                ProductType.TSHIRT,
                ProductType.VOUCHER,
                ProductType.VOUCHER,
                ProductType.PANTS,
                ProductType.TSHIRT,
                ProductType.TSHIRT
            };

            foreach (var item in items)
            {
                Checkout.Scan(item);
            }

            var totalPrice = Checkout.CalculateTotal();

            Assert.AreEqual(74.5M, totalPrice);
        }

    }
}
