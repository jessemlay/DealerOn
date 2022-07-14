using DealerOn.Models;
using System;

namespace DealerOn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _cart = new Cart();
            Product[] products = new Product[]
                 {
                           new Product() { Name = "Book", Price = 12.49m, Quantity = 1, Category = new Category() { Name = Category.Categories.Books, SalesTax = false   }},
                           new Product() { Name = "Book", Price = 12.49m, Quantity =1,   Category = new Category() { Name = Category.Categories.Books, SalesTax = false   }},
                           new Product() { Name = "Music CD", Price = 14.99m, Quantity =1, Category = new Category() { Name = Category.Categories.Other, SalesTax = true   }},
                           new Product() { Name = "Chocalate bar", Price = 0.85m, Quantity =1, Category = new Category() { Name = Category.Categories.Food, SalesTax = false   }},
                           new Product() { Name = "Imported box of chocalates", Price = 10.00m, Imported = true, Quantity =1, Category = new Category() { Name = Category.Categories.Food, SalesTax = false   }},
                           new Product() { Name = "Imported bottle of perfume", Price = 47.50m, Imported = true, Quantity =1, Category = new Category() { Name = Category.Categories.Other, SalesTax = true   }},
                 };
            foreach (var item in products)
            {
                _cart.Add(item);
            }

            var result = _cart.Purchase();
            Console.WriteLine(result);
        }
    }
}
