using DealerOn.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DealerOn.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestWithSalesTax()
        {
            var _cart = new Cart();
            var cd  = new Product() { Name = "Music CD", Price = 14.99m, Quantity = 1, Category = new Category() { Name = Category.Categories.Other, SalesTax = true } };

            _cart.Add(cd);

            Assert.IsTrue(_cart.Products.Single(p => p.Name == "Music CD").TotalPrice == 16.49m);
           
        }

        [TestMethod]
        public void TestWithoutSalesTax()
        {
            var _cart = new Cart();
            var book = new Product() { Name = "Book", Price = 12.49m, Quantity = 1, Category = new Category() { Name = Category.Categories.Books, SalesTax = false } };

            _cart.Add(book);

            Assert.IsTrue(_cart.Products.Single(p => p.Name == "Book").TotalPrice == 12.49m);

        }

        [TestMethod]
        public void TestWithSalesTaxAndWithImportTax()
        {
            var _cart = new Cart();
            var perfume = new Product() { Name = "Imported bottle of perfume", Price = 47.50m, Imported = true, Quantity = 1, Category = new Category() { Name = Category.Categories.Other, SalesTax = true } };

            _cart.Add(perfume);

            Assert.IsTrue(_cart.Products.Single(p => p.Name == "Imported bottle of perfume").TotalPrice == 54.65m);

        }

        [TestMethod]
        public void TestWithoutSalesTaxAndWithImportTax()
        {
            var _cart = new Cart();
            var box = new Product() { Name = "Imported box of chocalates", Price = 10.00m, Imported = true, Quantity = 1, Category = new Category() { Name = Category.Categories.Food, SalesTax = false } };

            _cart.Add(box);

            Assert.IsTrue(_cart.Products.Single(p => p.Name == "Imported box of chocalates").TotalPrice == 10.50m);

        }


        [TestMethod]
        public void TestReceipt()
        {
            var _cart = new Cart();
            Product[] products = new Product[]
                 {
                           new Product() { Name = "Book", Price = 12.49m, Quantity = 1, Category = new Category() { Name = Category.Categories.Books, SalesTax = false   }},
                           new Product() { Name = "Book", Price = 12.49m, Quantity =1,   Category = new Category() { Name = Category.Categories.Books, SalesTax = false   }},
                           new Product() { Name = "Music CD", Price = 14.99m, Quantity =1, Category = new Category() { Name = Category.Categories.Other, SalesTax = true   }},
                           new Product() { Name = "Chocalate bar", Price = 0.85m, Quantity =1, Category = new Category() { Name = Category.Categories.Other, SalesTax = true   }},
                           new Product() { Name = "Imported box of chocalates", Price = 10.00m, Imported = true, Quantity =1, Category = new Category() { Name = Category.Categories.Food, SalesTax = false   }},
                           new Product() { Name = "Imported bottle of perfume", Price = 47.50m, Imported = true, Quantity =1, Category = new Category() { Name = Category.Categories.Other, SalesTax = true   }},
                 };

            foreach (var item in products)
            {
                _cart.Add(item);
            }

            var result = _cart.Purchase();

            var receipt =
                "Book: 24.98 (2 @ 12.49)\r\n" +
                "Music CD: 16.49\r\n" +
                "Chocalate bar: 0.95\r\n" +
                "Imported box of chocalates: 10.50\r\n" +
                "Imported bottle of perfume: 54.65\r\n";

            Assert.IsTrue(result == receipt);

        }


    }
}
