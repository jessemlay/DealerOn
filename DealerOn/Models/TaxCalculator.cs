using DealerOn.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DealerOn.Models
{
    public class TaxCalculator : ITaxCalculator
    {
        
        private static List<Category> TaxExemptCategories;

        public TaxCalculator()
        {
            TaxExemptCategories = new List<Category>();
            Category[] categories = new Category[]
                {
                        new Category() { Name = Category.Categories.Books, SalesTax = false   },
                        new Category() { Name = Category.Categories.Food, SalesTax = false  },
                        new Category() { Name = Category.Categories.Medical, SalesTax = false },                        
                };
            TaxExemptCategories.AddRange(categories);
            
        }

        public decimal Calculate(Product product)
        {
            var totalTax = 0m;

            // Calculate sales tax if applicable
            if (!TaxExemptCategories.Any(c => c.Name == product.Category.Name))
            {
                totalTax = Math.Ceiling(product.Price * 0.1m * 20) / 20;
            }

            // Calculate import tax if applicable
            if (product.Imported)
            {
                totalTax += Math.Ceiling(product.Price * 0.05m * 20) / 20;
            }

            return totalTax;
        }
    }
}
